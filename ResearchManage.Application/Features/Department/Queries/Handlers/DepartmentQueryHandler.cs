using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Department.Queries.Models;
using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Application.Features.Researchers.Queries.Models;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;
using ResearchManage.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : MyResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, MyResponse<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentByIdWithScholarsQuery, MyResponse<GetDepartmentByIdWithScholarsResponse>>,
        IRequestHandler<GetDepartmentByIdWithSupervisorQuery,MyResponse<GetDepartmentByIdWithSupervisorRespone>>

    {
        #region Fileds
        private readonly IDepartmentServices _DepartmentServices;
        private readonly IScholarServices _ScholarServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DepartmentQueryHandler(IDepartmentServices _departmentServices, IMapper mapper, IStringLocalizer<SharedResources> stringLoca, IScholarServices scholarServices) : base(stringLoca)
        {

            _DepartmentServices = _departmentServices;
            _ScholarServices = scholarServices;
            _mapper = mapper;
            _stringLocalizer = stringLoca;

        }



        #endregion

        #region Handle Functions


        public async Task<MyResponse<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _DepartmentServices.GetDepartmentById(request.Id);
            if (response == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var mapper = new GetDepartmentByIdResponse
            {
                ID = response.ID,
                Name = response.Name,
                Description = response.Description,
                scholarsList = response.Scholars.Select(s => new ScholarsDTORespons { ID = s.ID, Name = s.Name }).ToList(),
                superVisorList = response.Supervisors.Select(s => new SuperVisorDTORespons { ID = s.ID, Name = s.Name }).ToList()
            };

            return Success(mapper);


        }

        public async Task<MyResponse<GetDepartmentByIdWithScholarsResponse>> Handle(GetDepartmentByIdWithScholarsQuery request, CancellationToken cancellationToken)
        {

            var response = await _DepartmentServices.GetDepartmentById(request.DepartmentID);
            if (response == null) return NotFound<GetDepartmentByIdWithScholarsResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var mapper=new GetDepartmentByIdWithScholarsResponse(response.ID,response.Name);
            


            Expression<Func<Scholar, ScholarsDTORespons>> expression =
                e => new ScholarsDTORespons() {ID=e.ID,Name=e.Name,Bio=e.Bio };

            //var Querable = _scholarServices.GetResearcherQueryable();
            var Querable = _ScholarServices.GetScholarByQueryable(s => s.DepartmentID == request.DepartmentID);

            var PaginatedList = await Querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            
            mapper.ScholarsList = PaginatedList;
            return Success(mapper);
           
        }

        public async Task<MyResponse<GetDepartmentByIdWithSupervisorRespone>> Handle(GetDepartmentByIdWithSupervisorQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }




        #endregion

    }
}

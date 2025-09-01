using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Research.Queries.Models;
using ResearchManage.Application.Features.Research.Queries.Respones;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;
using System.Linq.Expressions;

namespace ResearchManage.Application.Features.Research.Queries.Handlers
{
    public class ResearchQueryHandler : MyResponseHandler,
        IRequestHandler<GetResearchByIdQuery, MyResponse<GetResearchByIdResponse>>,
        IRequestHandler<GetResearchPaginationQuery, PaginatedList<GetResearchPaginationResponse>>
    {
        #region Fileds
        private readonly IDepartmentServices _DepartmentServices;
        private readonly IResearchServices _ResearchServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ResearchQueryHandler(IDepartmentServices _departmentServices, IMapper mapper, IStringLocalizer<SharedResources> stringLoca, IResearchServices ResearchServices) : base(stringLoca)
        {

            _DepartmentServices = _departmentServices;
            _ResearchServices = ResearchServices;
            _mapper = mapper;
            _stringLocalizer = stringLoca;

        }
        #endregion


        #region Handle Functions
        public async Task<MyResponse<GetResearchByIdResponse>> Handle(GetResearchByIdQuery request, CancellationToken cancellationToken)
        {
            var Research = await _ResearchServices.GetResearchByIdWithIncludeAsync(request.Id);
            if (Research == null)
            {
                return NotFound<GetResearchByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var researcherMapper = _mapper.Map<GetResearchByIdResponse>(Research);
            return Success(researcherMapper);
        }

        public async Task<PaginatedList<GetResearchPaginationResponse>> Handle(GetResearchPaginationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Research, GetResearchPaginationResponse>> expression =
                e => new GetResearchPaginationResponse(e.ID, e.Title, e.scholar.Name, e.department.Name);

            var Querable = _ResearchServices.FilterResearchQueryble(request.OrderBy, request.SearchonData);
            var PaginatedList = await Querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return PaginatedList;



        }


        #endregion

    }
}

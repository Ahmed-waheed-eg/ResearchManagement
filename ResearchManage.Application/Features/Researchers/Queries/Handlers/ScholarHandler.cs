using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Researchers.Queries.Models;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Queries.Handlers
{
    public class ScholarHandler :MyResponseHandler,
        IRequestHandler<GetScholarsListQuery, MyResponse<List<ScholarDTO>>>,
        IRequestHandler<GetScholarByIDQuery, MyResponse<ScholarDTO>>,
        IRequestHandler<GetScholarPaginationQuery, PaginatedList<GetScholarPaginationResponse>>
    {
        #region Fileds
        private readonly IScholarServices _ScholarServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ScholarHandler(IScholarServices ScholarServices ,IMapper mapper,IStringLocalizer<SharedResources> stringLoca):base(stringLoca) {
        
            _ScholarServices = ScholarServices;
            _mapper = mapper;
            _stringLocalizer = stringLoca;

        }
        #endregion

        #region Handle Functions
        public async Task<MyResponse<List<ScholarDTO>> >Handle(GetScholarsListQuery request, CancellationToken cancellationToken)
        {
            
            var scholarList =  await _ScholarServices.GetScholarListAsync();
            var scholarListMapper= _mapper.Map<List<ScholarDTO>>(scholarList);
            return Success(scholarListMapper);
        }

        public async Task<MyResponse<ScholarDTO>> Handle(GetScholarByIDQuery request, CancellationToken cancellationToken)
        {
            var scholar = await _ScholarServices.GetScholarByIdWithIncludeAsync(request.ID);
            if (scholar == null)
            {
                return NotFound<ScholarDTO>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var researcherMapper = _mapper.Map<ScholarDTO>(scholar);
            return Success(researcherMapper);
        }

        public async Task<PaginatedList<GetScholarPaginationResponse>> Handle(GetScholarPaginationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Scholar, GetScholarPaginationResponse>> expression =
                  e => new GetScholarPaginationResponse(e.ID, e.Name, e.Department.Name,e.Bio);

            //var Querable = _scholarServices.GetResearcherQueryable();
            var Querable = _ScholarServices.FilterScholarQueryble(request.OrderBy, request.SearchonData);

            var PaginatedList =await Querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
           
            return PaginatedList;
        }



        #endregion

    }
}

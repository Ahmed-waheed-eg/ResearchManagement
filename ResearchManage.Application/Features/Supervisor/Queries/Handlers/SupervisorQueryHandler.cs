using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Supervisor.Queries.Models;
using ResearchManage.Application.Features.Supervisor.Queries.Respones;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;
using System.Linq.Expressions;

namespace ResearchManage.Application.Features.Supervisor.Queries.Handlers
{
    public class SupervisorQueryHandler : MyResponseHandler,
        IRequestHandler<GetSuoervisorByIdQuery, MyResponse<GetSuoervisorByIdRespons>>,
        IRequestHandler<GetSupervisorPaginationQuery, PaginatedList<GetSupervisorPaginationResponse>>
    {
        #region Fileds
        private readonly ISupervisorServices _supervisorServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public SupervisorQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLoca, ISupervisorServices supervisorServices) : base(stringLoca)
        {
            _mapper = mapper;
            _stringLocalizer = stringLoca;
            _supervisorServices = supervisorServices;
        }


        #endregion


        #region Handle Functions

        public async Task<MyResponse<GetSuoervisorByIdRespons>> Handle(GetSuoervisorByIdQuery request, CancellationToken cancellationToken)
        {
            var Supervisor = await _supervisorServices.GetSupervisorByIdWithIncludeAsync(request.ID);
            if (Supervisor == null)
            {
                return NotFound<GetSuoervisorByIdRespons>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var Mapper = _mapper.Map<GetSuoervisorByIdRespons>(Supervisor);
            return Success(Mapper);
        }

        public async Task<PaginatedList<GetSupervisorPaginationResponse>> Handle(GetSupervisorPaginationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Supervisor, GetSupervisorPaginationResponse>> expression =
       e => new GetSupervisorPaginationResponse(e.ID, e.Name);

            //var Querable = _scholarServices.GetResearcherQueryable();
            var Querable = _supervisorServices.FilterSupervisorQueryble(request.SearchonData);

            var PaginatedList = await Querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return PaginatedList;
        }
        #endregion
    }
}

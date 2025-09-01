using AutoMapper;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Admin.Queries.Handlers
{
    public class AdminQueryHandler : MyResponseHandler
    {
        #region Fileds
        private readonly IAdminServices _adminServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AdminQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLoca, IAdminServices adminServices) : base(stringLoca)
        {
            _adminServices = adminServices;
            _mapper = mapper;
            _stringLocalizer = stringLoca;

        }
        #endregion


        #region Handle Functions


        #endregion
    }
}

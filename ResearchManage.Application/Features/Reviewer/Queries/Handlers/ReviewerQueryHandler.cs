using AutoMapper;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Reviewer.Queries.Handlers
{
    public class ReviewerQueryHandler : MyResponseHandler
    {

        #region Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IReviewerServices _reviewerServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ReviewerQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLoca, IReviewerServices reviewerServices) : base(stringLoca)
        {
            _mapper = mapper;
            _reviewerServices = reviewerServices;
            _stringLocalizer = stringLoca;

        }
        #endregion


        #region Handle Functions


        #endregion

    }
}
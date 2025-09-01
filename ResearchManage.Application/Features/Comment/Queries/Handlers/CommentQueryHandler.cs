using AutoMapper;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Comment.Queries.Handlers
{
    public class CommentQueryHandler : MyResponseHandler
    {
        #region Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ICommentServices _commentServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public CommentQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLoca, ICommentServices commentServices) : base(stringLoca)
        {
            _commentServices = commentServices;
            _mapper = mapper;
            _stringLocalizer = stringLoca;

        }
        #endregion


        #region Handle Functions


        #endregion
    }
}

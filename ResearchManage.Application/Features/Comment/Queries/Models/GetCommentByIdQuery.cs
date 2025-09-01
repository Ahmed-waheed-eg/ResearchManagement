using MediatR;
using ResearchManage.Application.Features.Comment.Queries.Respones;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Comment.Queries.Models
{
    public class GetCommentByIdQuery : IRequest<MyResponse<GetCommentByIdResponse>>
    {
        public int ID { get; set; }

        public GetCommentByIdQuery(int id)
        {
            ID = id;
        }
    }
}

using MediatR;
using ResearchManage.Application.Features.Reviewer.Queries.Respones;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Reviewer.Queries.Models
{
    public class GetReviewerByIdQuery : IRequest<MyResponse<GetReviewerByIdResponse>>
    {
        public int ID { get; set; }

        public GetReviewerByIdQuery(int id)
        {
            ID = id;
        }
    }
}

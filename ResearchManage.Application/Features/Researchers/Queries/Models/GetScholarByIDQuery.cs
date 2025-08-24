using MediatR;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Researchers.Queries.Models
{
    public class GetScholarByIDQuery : IRequest<MyResponse<ScholarDTO>>
    {

        public int ID { get; set; }

        public GetScholarByIDQuery(int id)
        {
            ID = id;
        }
    }
}

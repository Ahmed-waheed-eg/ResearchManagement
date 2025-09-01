using MediatR;
using ResearchManage.Application.Features.Supervisor.Queries.Respones;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Supervisor.Queries.Models
{
    public class GetSuoervisorByIdQuery : IRequest<MyResponse<GetSuoervisorByIdRespons>>
    {
        public int ID { get; set; }

        public GetSuoervisorByIdQuery(int id)
        {
            ID = id;
        }
    }
}

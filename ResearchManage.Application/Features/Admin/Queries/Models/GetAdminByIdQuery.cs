using MediatR;
using ResearchManage.Application.Features.Admin.Queries.Respones;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Admin.Queries.Models
{
    public class GetAdminByIdQuery : IRequest<MyResponse<GetAdminByIdResponse>>
    {
        public int ID { get; set; }

        public GetAdminByIdQuery(int id)
        {
            ID = id;
        }
    }
}

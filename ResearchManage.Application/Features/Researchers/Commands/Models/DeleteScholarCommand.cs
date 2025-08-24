using MediatR;
using ResearchManage.Application.ResponseBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Commands.Models
{
    public class DeleteScholarCommand:IRequest<MyResponse<string>>
    {
        public int Id { get; set; }

        public DeleteScholarCommand(int id)
        {
            this.Id = id;
        }
    }
}

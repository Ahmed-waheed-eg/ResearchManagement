using ResearchManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Research.Queries.Respones
{
    public class GetResearchByIdResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Abestract { get; set; }
        public string? Notes { get; set; }

        public int ScholarId { get; set; }
        public string scholarName { get; set; }

        public int SupervisorID { get; set; }
        public string SupervisorName { get; set; }

        public int DepartmentID { get; set; }
        public string DepartmentName{ get; set; }

    }
}

using ResearchManage.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Respones
{
    public class GetDepartmentByIdWithSupervisorRespone
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public PaginatedList<SuperVisorDTORespons>? SupervisorList { get; set; }

        public GetDepartmentByIdWithSupervisorRespone(int departmentId, string departmentName)
        {
            this.DepartmentId = departmentId;
            this.DepartmentName = departmentName;
        }
    }
}

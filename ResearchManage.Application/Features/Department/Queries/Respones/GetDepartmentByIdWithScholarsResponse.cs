using ResearchManage.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Respones
{
    public class GetDepartmentByIdWithScholarsResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public PaginatedList<ScholarsDTORespons>? ScholarsList { get; set; }

        public GetDepartmentByIdWithScholarsResponse(int departmentId, string departmentName)
        {
            this.DepartmentId = departmentId;
            this.DepartmentName = departmentName;
        }
    }
    
}

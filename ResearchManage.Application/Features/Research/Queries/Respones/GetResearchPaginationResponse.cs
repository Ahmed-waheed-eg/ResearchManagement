using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Research.Queries.Respones
{
    public class GetResearchPaginationResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string scholarName { get; set; }
        public string DepartmentName { get; set; }

        public GetResearchPaginationResponse(int iD, string title, string scholarName, string departmentName)
        {
            ID = iD;
            Title = title;
            this.scholarName = scholarName;
            DepartmentName = departmentName;
        }
    }
}

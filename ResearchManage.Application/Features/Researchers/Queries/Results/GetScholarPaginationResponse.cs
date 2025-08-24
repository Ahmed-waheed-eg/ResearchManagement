using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Queries.Results
{
    public class GetScholarPaginationResponse
    {

        public int ScholarID { get; set; }
        public string ScholarName { get; set; }
        public string? Bio { get; set; }
        public string DepartmentName { get; set; }

        public GetScholarPaginationResponse(int scholarid,string scholarName, string departmentName, string? bio)
        {
            ScholarID = scholarid;
            ScholarName = scholarName;
            DepartmentName = departmentName;
            Bio = bio;
        }
    }
}

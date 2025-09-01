using ResearchManage.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Respones
{
    public class GetDepartmentByIdWithResearchesRespone
    {
     
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public PaginatedList<ResearchPagRespon>? ResrchesList { get; set; }
 
        public GetDepartmentByIdWithResearchesRespone( int id,string name,string description )
        {

            ID = id;
            Name = name;
            Description = description;
        }
    }

    public class ResearchPagRespon
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ScholarName { get; set; }
        public ResearchPagRespon(int iD, string title, string scholarName)
        {
            ID = iD;
            Title = title;
            ScholarName = scholarName;
        }
    }
}

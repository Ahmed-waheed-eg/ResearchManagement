using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Respones
{
    public  class GetDepartmentByIdResponse 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScholarsDTORespons>? scholarsList { get; set; }
        public List<SuperVisorDTORespons>? superVisorList { get; set; }
    }

    public class ScholarsDTORespons
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }
    }

    public class SuperVisorDTORespons
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Queries.Results
{
    public class ScholarDTO
    {
        public int ID { get; set; }

        public string? Bio { get; set; }
        public string Name { get; set; }

        public string? DepartmentName { get; set; }
    }
}

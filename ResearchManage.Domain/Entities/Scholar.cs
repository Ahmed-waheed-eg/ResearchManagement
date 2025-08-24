using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Domain.Entities
{
    public class Scholar
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string? Bio { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }  

        public ICollection<Research> Researches { get; set; }
    }
}

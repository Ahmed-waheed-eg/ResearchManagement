using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Domain.Entities
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Scholar> Scholars { get; set; }
        public ICollection<Research> Researches { get; set; }
        public ICollection<Supervisor > Supervisors { get; set; }
    }
}

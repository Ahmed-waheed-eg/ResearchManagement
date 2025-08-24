using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Domain.Entities
{
    public class Research
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Abestract {  get; set; }
        public string? Notes { get; set; }

        public int ResearcherID { get; set; }
        public Scholar scholar { get; set; }

        public int SupervisorID { get; set; }
        public Supervisor Supervisor { get; set; }

        public int DepartmentID { get; set; }
        public Department department { get; set; }

        public ICollection<Comment> comments { get; set; }



    }
}

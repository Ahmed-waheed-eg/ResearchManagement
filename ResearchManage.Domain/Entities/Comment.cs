using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int ResearchId { get; set; }
        public Research research { get; set; }

        public int ReviewerId { get; set; } 
        public Reviewer reviewer { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime dateTime { get; set; }= DateTime.Now;
    }
}

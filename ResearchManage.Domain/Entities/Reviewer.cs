using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Domain.Entities
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

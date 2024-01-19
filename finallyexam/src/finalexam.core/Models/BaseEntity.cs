using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CrteatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

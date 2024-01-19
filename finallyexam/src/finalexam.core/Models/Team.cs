using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.core.Models
{
    public class Team:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(80)]
        public string Profession { get; set; }
        [StringLength(100)]
        public string? ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}

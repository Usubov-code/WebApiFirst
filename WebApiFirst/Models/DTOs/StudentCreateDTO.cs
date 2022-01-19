using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFirst.Models.DTOs
{
    public class StudentCreateDTO
    {
        [MaxLength(50),Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}

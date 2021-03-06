using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFirst.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}

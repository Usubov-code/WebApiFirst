using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),MinLength(3)]
        public string Name { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Surname { get; set; }
       
        public byte Age { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
       
    }
}

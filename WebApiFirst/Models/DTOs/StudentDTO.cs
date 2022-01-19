using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFirst.Models.DTOs
{
    public class StudentDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public int ClassId { get; set; }
        public ClassDTO Class { get; set; }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFirst.Data;
using WebApiFirst.Models;
using WebApiFirst.Models.DTOs;

namespace WebApiFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StudentGet()
        {
            List<StudentDTO> model = _context.Students
                                                 .Include(c => c.Class)
                                                 .Select(m => new StudentDTO
                                                 {
                                                     Id = m.Id,
                                                     Name = m.Name,
                                                     Surname = m.Surname,
                                                     Age = m.Age,
                                                     ClassId = m.ClassId,
                                                     Class = new ClassDTO { Id = m.ClassId, Name = m.Class.Name }

                                                 }).ToList();


            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult StudentGet(int id)     
        {
            StudentDTO model = _context.Students
                                                 .Include(c => c.Class)
                                                 .Select(m => new StudentDTO
                                                 {
                                                     Id = m.Id,
                                                     Name = m.Name,
                                                     Surname = m.Surname,
                                                     Age = m.Age,
                                                     ClassId = m.ClassId,
                                                     Class = new ClassDTO { Id = m.ClassId, Name = m.Class.Name }

                                                 }).FirstOrDefault(m => m.Id == id);


            return Ok(model);
        }
        [HttpPost]

        public IActionResult Create(StudentCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                Student newModel = new Student()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Age = model.Age,
                    ClassId = model.ClassId,
                };

                _context.Students.Add(newModel);
                _context.SaveChanges();
                return Ok(newModel);
            }

            ModelState.AddModelError("Erorr Test", "Model Is not Valid");

            return StatusCode(StatusCodes.Status404NotFound, "Model is Not Valid 404");

        }

        [HttpPatch]

        public IActionResult Update([FromHeader]int? id,[FromBody]StudentCreateDTO DTOmodel)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Student model = _context.Students.Find(id);
            if (model == null)
            {
                return BadRequest();

            }
            model.Name = DTOmodel.Name;
            model.Surname = DTOmodel.Surname;
            model.Age = DTOmodel.Age;
            model.ClassId = DTOmodel.ClassId;


            _context.Students.Update(model);
            _context.SaveChanges();





            return Ok(DTOmodel);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();

            }

            Student model = _context.Students.Find(id);
            if (model==null)
            {
                return NotFound();

            }

            _context.Students.Remove(model);
            _context.SaveChanges();

            return Ok(model);

        }

    }
}

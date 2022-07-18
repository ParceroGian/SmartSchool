using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var prof = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não econtrado");
            }
            return Ok(prof);
        }

        [HttpGet("{ByName}")]
        public IActionResult GetByName(string nome)
        {
            var prof = _context.Professores.FirstOrDefault(x => x.Nome.Contains(nome));

            if (prof == null)
            {
                BadRequest("Professor Not Found");
            }

            return Ok(prof);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();

            return CreatedAtAction(
            nameof(GetById),
            new { IdProfessor = professor.Id }, professor);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(X => X.Id == id);

            if (prof == null)
            {
                return BadRequest("Professor não econtrado");
            }
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("Id")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(X => X.Id == id);

            if (prof == null)
            {
                return BadRequest("Professor não econtrado");
            }
            _context.SaveChanges();

            return Ok(professor);
        }

    }
}

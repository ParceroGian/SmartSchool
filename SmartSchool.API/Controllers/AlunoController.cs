using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //api/aluno/ById?id=1
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {

            var alu = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alu == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(alu);
            }

        }

        //api/aluno/Byname?nome=Rafael&sobrenome=Giandoso
        [HttpGet("{ByName}")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var alu = _context.Alunos.FirstOrDefault(x =>
            x.Nome.Contains(nome)
            && x.Sobrenome.Contains(sobrenome));

            if (alu == null)
                return NotFound();
            else
                return Ok(alu);
        }

        [HttpPost]
        public IActionResult PostAluno([FromBody] Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();

            return CreatedAtAction(
            nameof(GetById),
            new { IdAluno = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno)
        {
            var alu = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alu == null)
            {
                return NotFound();
            }
            else
            {
                _context.Update(aluno);
                _context.SaveChanges();
            }
            return Ok(aluno);        }

        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, Aluno aluno)
        {
            var alu = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alu == null)
            {
                return NotFound("Id não Econtrado");
            }
            else
            {
                _context.Update(aluno);
                _context.SaveChanges();
            }
            return Ok(aluno);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var alu = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alu == null)
                return NotFound();
            else
                _context.Alunos.Remove(alu);
            return Ok();
        }
    }
}

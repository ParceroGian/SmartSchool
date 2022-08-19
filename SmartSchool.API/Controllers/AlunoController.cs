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

        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var source = _repo.GetAllAlunos();

            if (source == null)
            {
                return BadRequest();
            }

            return Ok(source);
        }

        //api/aluno/ById?id=1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var aluno = _repo.GetAlunoById(id, true);
            if (aluno == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(aluno);
            }

        }

        //api/aluno/Byname?nome=Rafael&sobrenome=Giandoso
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var alu = _repo.GetAlunoByName(nome);

            if (alu == null)
                return NotFound();
            else
                return Ok(alu);
        }

        [HttpPost]
        public IActionResult PostAluno([FromBody] Aluno aluno)
        {
            _repo.Add(aluno);
            _repo.SaveChanges();

            return CreatedAtAction(
            nameof(GetById),
            new { IdAluno = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
            {
                return NotFound();
            }
            else
            {
                _repo.Update(aluno);
                _repo.SaveChanges();
            }
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
            {
                return NotFound("Id não Econtrado");
            }
            else
            {
                _repo.Update(aluno);
                _repo.SaveChanges();
            }
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
            {
                return NotFound();
            }
            else
            {
                _repo.Delete(alu);
                _repo.SaveChanges();
            }

            return Ok();
        }
    }
}

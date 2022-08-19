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
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var source = _repo.GetAllProfessores();
            return Ok(source);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prof = _repo.GetProfessorById(id, true);
            if (prof == null)
            {
                return BadRequest("Professor não econtrado");
            }
            return Ok(prof);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var prof = _repo.GetProfessorByName(nome);

            if (prof == null)
            {
                BadRequest("Professor Not Found");
            }

            return Ok(prof);
        }
         //  analizar essa rota
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            _repo.Add(professor);
            _repo.SaveChanges();

            return Created("Professor cadastrado com sucesso", professor);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("Professor não econtrado");

            _repo.Update(professor);
            if (_repo.SaveChanges()) ;
            {
                return Ok(professor);
            }

            return BadRequest("Dados não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("Professor não econtrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Atualizado com sucesso");
            }
            return BadRequest("Dados não atualizados");
        }

        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
            {
                return NotFound(" Professor nao encontrado");
            }
            else
            {
                _repo.Delete(prof);
                _repo.SaveChanges();
            }

            return Ok();
        }

    }
}

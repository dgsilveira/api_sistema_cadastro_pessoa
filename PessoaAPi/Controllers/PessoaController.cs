using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PessoaAPi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PessoaAPi.Data;

namespace PessoaAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPessoaPorId), new { Id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IEnumerable<Pessoa> RecuperaPessoas()
        {
            return _context.Pessoas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPessoaPorId(int id)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if (pessoa != null)
            {
                return Ok(pessoa);
            }
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizaPessoa(int id, [FromBody] Pessoa pessoaNova)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if(pessoa == null)
            {
                return NotFound();
            }
            pessoa.Nome = pessoaNova.Nome;
            pessoa.Email = pessoaNova.Email;
            pessoa.Idade = pessoaNova.Idade;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPessoa(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(pessoa =>pessoa.Id == id);
            if(pessoa == null)
            {
                return NotFound();
            }
            _context.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

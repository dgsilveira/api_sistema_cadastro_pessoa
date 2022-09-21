using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PessoaAPi.Models;
using System.Linq;

namespace PessoaAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaPessoa(Pessoa pessoa)
        {
            pessoa.Id = id++;
            pessoas.Add(pessoa);
            return CreatedAtAction(nameof(RecuperaPessoaPorId), new { Id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IActionResult RecuperarPessoa()
        {
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPessoaPorId(int id)
        {
            Pessoa pessoa = pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if(pessoa != null)
            {
                return Ok(pessoa);
            }
            return NotFound();
        }
    }
}

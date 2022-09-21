using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PessoaAPi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PessoaAPi.Data;
using PessoaAPi.Data.Dtos;
using System;
using AutoMapper;

namespace PessoaAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private PessoaContext _context;
        private IMapper _mapper;

        public PessoaController(PessoaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaPessoa([FromBody] CreatePessoaDto createPessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(createPessoaDto);
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
            var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if (pessoa != null)
            {
                var readPessoaDto = _mapper.Map<ReadPesssoaDto>(pessoa);
                return Ok(readPessoaDto);
            }
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizaPessoa(int id, [FromBody] UpdatePessoaDto updatePessoaDto)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if(pessoa == null)
            {
                return NotFound();
            }
            _mapper.Map(updatePessoaDto, pessoa);
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

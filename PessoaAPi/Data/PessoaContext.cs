using PessoaAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace PessoaAPi.Data
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}

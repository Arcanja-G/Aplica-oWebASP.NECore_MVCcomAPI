using helloword_projeto.Models;
using Microsoft.EntityFrameworkCore;

namespace helloword_projeto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Produto> Produtos {get; set;} //Db - classe e Produtos é uma tabela
        public DbSet<Cliente> Clientes { get; set; } //Db - classe e Produtos é uma tabela
    }
}

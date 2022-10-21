using MagSeguros.Data.Map;
using MagSeguros.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MagSeguros.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<SeguradoModel> Segurado { get; set; }
        public DbSet<FuncionarioModel> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeguradoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

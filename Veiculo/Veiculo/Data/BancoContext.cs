using Microsoft.EntityFrameworkCore;
using Veiculo.Models;

namespace Veiculo.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext ( DbContextOptions<BancoContext> options ) : base( options )
        { }

        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<MotoModel> Motos { get; set; }
        public DbSet<UsuarioModel> Usuários { get; set; }

    }
}

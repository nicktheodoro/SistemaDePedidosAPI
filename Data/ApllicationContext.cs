using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SitemaDePedidosAPI.Domain;

namespace SitemaDePedidosAPI.Data
{
    public class ApllicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger) // loga as ações no console
                .EnableSensitiveDataLogging() // libera para que os valores sejam mostrados no console
                .UseNpgsql("Host=localhost;Database=sistema_pedidos;Username=postgres;Password=admin");
        }

        //Override no OnModelCreating permite montar a tabela de forma manual
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // chama o builder da interface IEntityTypeConfiguration uma por uma
            // modelBuilder.ApplyConfiguration(new ClienteConfiguration()); 
            // modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            // modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
            // modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            //-----------------------------//---------------------------------//

            //Configura qual Assembly tem que ser varrido para implementar todas classes concretas
            //que possuem interface IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApllicationContext).Assembly);
        }
    }
}
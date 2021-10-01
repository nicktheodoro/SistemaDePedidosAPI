using Microsoft.EntityFrameworkCore;

namespace SitemaDePedidosAPI.Data
{
    public class ApllicationContext : DbContext
    {
        //Com o DbSet o ORM Mapea automáticamente a minha classe;
        // public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=sistema_pedidos;Username=postgres;Password=admin");
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
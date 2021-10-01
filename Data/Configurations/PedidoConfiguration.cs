using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SitemaDePedidosAPI.Domain;

namespace SitemaDePedidosAPI.Data.Configurations
{
    // Desacopla as regras de configuração de modelo de dados por tabela
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.InicadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd(); //pega hora atual e define valor default
            builder.Property(p => p.Status).HasConversion<string>();//converte para string, para salvar o enum
            builder.Property(p => p.TipoFrete).HasConversion<int>();//converte para int, para salvar o enum
            builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

            //Relacionamento N 1
            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade); //deleta em cascata
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class GrupoClienteConfiguration : IEntityTypeConfiguration<GrupoCliente>
    {
        public void Configure(EntityTypeBuilder<GrupoCliente> builder)
        {
            builder
                .ToTable("TB_GRUPO_CLIENTE");

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.GrupoId)
                .HasColumnName("GrupoId")
                .IsRequired();

            builder
                .Property(p => p.ClienteId)
                .HasColumnName("ClienteId")
                .IsRequired();

            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.GrupoClientes)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.GrupoClientes)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => p.ClienteId)
                .IsUnique()
                .HasDatabaseName("IX_Unq_GrupoCliente_ClienteId");

        }
    }
}

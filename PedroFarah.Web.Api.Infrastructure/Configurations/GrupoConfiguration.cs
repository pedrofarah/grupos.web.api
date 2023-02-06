using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder
                .ToTable("TB_GRUPO");

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class GerenteConfiguration : IEntityTypeConfiguration<Gerente>
    {
        public void Configure(EntityTypeBuilder<Gerente> builder)
        {
            builder
                .ToTable("TB_GERENTE");

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

            builder
                .Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder
                .Property(p => p.Nivel)
                .HasColumnName("Nivel")
                .IsRequired();

        }
    }
}

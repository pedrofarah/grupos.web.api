using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("TB_CLIENTE");

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.CNPJ)
                .HasColumnName("CNPJ");

            builder
                .Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder
                .Property(p => p.DataFundacao)
                .HasColumnName("DataFundacao");

        }
    }
}

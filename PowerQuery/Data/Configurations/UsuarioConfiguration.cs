using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerQuery.Entities;

namespace PowerQuery.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
   public void Configure(EntityTypeBuilder<Usuario> builder)
   {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name).HasColumnType("VARCHAR(80)").IsRequired();
      builder.Property(x => x.Cpf).HasColumnType("CHAR(11)").IsRequired();
      builder.Property(x => x.Idade).HasColumnType("INT").IsRequired();
   }
}
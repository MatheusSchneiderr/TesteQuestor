using Microsoft.EntityFrameworkCore;
using TesteQuestor.Models;

namespace TesteQuestor.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Banco> Bancos => Set<Banco>();
    public DbSet<Boleto> Boletos => Set<Boleto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.ToTable("bancos");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id)
                  .HasColumnName("id")
                  .UseIdentityByDefaultColumn();

            entity.Property(b => b.NomeBanco)
                  .HasColumnName("nome_banco")
                  .HasMaxLength(150)
                  .IsRequired();

            entity.Property(b => b.CodigoBanco)
                  .HasColumnName("codigo_banco")
                  .HasMaxLength(20)
                  .IsRequired();

            entity.HasIndex(b => b.CodigoBanco).IsUnique();

            entity.Property(b => b.PercentualJuros)
                  .HasColumnName("percentual_juros")
                  .HasColumnType("numeric(9,4)")
                  .IsRequired();
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.ToTable("boletos");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id)
                  .HasColumnName("id")
                  .UseIdentityByDefaultColumn();

            entity.Property(b => b.NomePagador)
                  .HasColumnName("nome_pagador")
                  .HasMaxLength(150)
                  .IsRequired();

            entity.Property(b => b.CpfCnpjPagador)
                  .HasColumnName("cpf_cnpj_pagador")
                  .HasMaxLength(14)
                  .IsRequired();

            entity.Property(b => b.NomeBeneficiario)
                  .HasColumnName("nome_beneficiario")
                  .HasMaxLength(150)
                  .IsRequired();

            entity.Property(b => b.CpfCnpjBeneficiario)
                  .HasColumnName("cpf_cnpj_beneficiario")
                  .HasMaxLength(14)
                  .IsRequired();

            entity.Property(b => b.Valor)
                  .HasColumnName("valor")
                  .HasColumnType("numeric(14,2)")
                  .IsRequired();

            entity.Property(b => b.DataVencimento)
                  .HasColumnName("data_vencimento")
                  .IsRequired();

            entity.Property(b => b.Observacao)
                  .HasColumnName("observacao")
                  .HasMaxLength(500);

            entity.Property(b => b.BancoId)
                  .HasColumnName("banco_id")
                  .IsRequired();

            entity.HasOne(b => b.Banco)
                  .WithMany(bc => bc.Boletos)
                  .HasForeignKey(b => b.BancoId)
                  .OnDelete(DeleteBehavior.NoAction);
        });
    }
}

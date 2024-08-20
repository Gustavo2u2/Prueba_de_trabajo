using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.server.Models;

public partial class ProyectoDbContext : DbContext
{
    public ProyectoDbContext()
    {
    }

    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    public virtual DbSet<Titulare> Titulares { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movimien__3214EC0729236FC9");

            entity.HasIndex(e => e.NumeroAutorizacion, "UQ__Movimien__DD54DC2BEFED0F20").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.NumeroAutorizacion).HasColumnName("Numero_autorizacion");
            entity.Property(e => e.TipoMov)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("Tipo_mov");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarjetas__3214EC0790E9AE59");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_CuotaMinima");
                    tb.HasTrigger("trg_InteresBonificable");
                    tb.HasTrigger("trg_TotalAPagar");
                });

            entity.HasIndex(e => e.NumeroTarjeta, "UQ__Tarjetas__F63C535F32FD34B1").IsUnique();

            entity.Property(e => e.IdTitular).HasColumnName("Id_titular");
            entity.Property(e => e.Interes).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.InteresBono)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Interes_bono");
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Numero_tarjeta");
            entity.Property(e => e.PagoMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pago_min");
            entity.Property(e => e.SaldoMin)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Saldo_min");
            entity.Property(e => e.SaldoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Saldo_total");
            entity.Property(e => e.TotalAPagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_a_pagar");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdTitular)
                .HasConstraintName("FK_Tarjetas_Titulares");
        });

        modelBuilder.Entity<Titulare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Titulare__3214EC073DDDE703");

            entity.Property(e => e.Apellido)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3214EC072540A56A");

            entity.Property(e => e.IdMovimiento).HasColumnName("Id_movimiento");
            entity.Property(e => e.IdTarjeta).HasColumnName("Id_tarjeta");

            entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdMovimiento)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Transacciones_Movimientos");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK_Transacciones_Tarjetas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

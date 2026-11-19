using System;
using System.Collections.Generic;
using DSWI_T1_05.Models.ViewModels.Citas;
using DSWI_T1_05.Models.ViewModels.Pacientes;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Data;

public partial class ClinicaBDContext : DbContext
{
    public ClinicaBDContext()
    {
    }

    public ClinicaBDContext(DbContextOptions<ClinicaBDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ClinicaBD;User Id=sa;Password=Admin123*;Encrypt=False;TrustServerCertificate=True;");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F275016ADF");

            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.Especialidad).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Citas__PacienteI__4CA06362");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07F94F38B7E");

            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("DNI");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

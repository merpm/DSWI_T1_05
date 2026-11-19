using System;
using System.Collections.Generic;
using DSWI_T1_05.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Data;

public partial class ClinicaDbContext : DbContext
{
    public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F282240888");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita).HasConstraintName("FK__Citas__PacienteI__267ABA7A");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07FEB404561");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

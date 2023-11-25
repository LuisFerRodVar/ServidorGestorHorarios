using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class SistemaContext : DbContext
{
    public SistemaContext()
    {
    }

    public SistemaContext(DbContextOptions<SistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Espacio> Espacios { get; set; }

    public virtual DbSet<HorarioAsignado> HorarioAsignados { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<ProfesorCurso> ProfesorCursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KFMKD8A;Database=sistema;Trust Server Certificate=true;User Id=administrador;Password=1234;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activida__3213E83FB031BF40");

            entity.ToTable("Actividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.Espacio).HasColumnName("espacio");
            entity.Property(e => e.HoraEntrada).HasColumnName("horaEntrada");
            entity.Property(e => e.HoraSalida).HasColumnName("horaSalida");
            entity.Property(e => e.IdEncargado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idEncargado");

            entity.HasOne(d => d.EspacioNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Espacio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__espac__5629CD9C");

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idEnc__5535A963");
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Correo).HasName("PK__Administ__2A586E0A9284BBFA");

            entity.ToTable("Administrador");

            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3213E83F5FDDD93B");

            entity.ToTable("Curso");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Carrera)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("carrera");
            entity.Property(e => e.Ciclo).HasColumnName("ciclo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Espacio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Espacio__3213E83FB30BA208");

            entity.ToTable("Espacio");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<HorarioAsignado>(entity =>
        {
            
                entity.HasKey(e => e.Id);
                entity.ToTable("HorarioAsignado");

            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.Espacio).HasColumnName("espacio");
            entity.Property(e => e.HoraEntrada).HasColumnName("horaEntrada");
            entity.Property(e => e.HoraSalida).HasColumnName("horaSalida");
            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");

            entity.HasOne(d => d.EspacioNavigation).WithMany()
                .HasForeignKey(d => d.Espacio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HorarioAs__espac__628FA481");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany()
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HorarioAs__idGru__6383C8BA");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3213E83F7F39497D");

            entity.ToTable("Profesor");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ProfesorCurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3213E83F9F908F70");

            entity.ToTable("ProfesorCurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Grupo).HasColumnName("grupo");
            entity.Property(e => e.IdCurso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idCurso");
            entity.Property(e => e.IdProfesor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idProfesor");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.ProfesorCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProfesorC__idCur__4F7CD00D");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.ProfesorCursos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProfesorC__idPro__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

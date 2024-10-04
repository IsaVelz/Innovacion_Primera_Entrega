using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Models
{
    public class InnovacionContext : DbContext
    {
        public InnovacionContext(DbContextOptions<InnovacionContext> options) : base(options)
        {
        }
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<CarInnovacion> CarInnovaciones { get; set; }
        public DbSet<ProgramaCI> ProgramaCIs { get; set; }
        public DbSet<PracticaEstrategia> PracticasEstrategias { get; set; }
        public DbSet<ProgramaPE> ProgramaPEs { get; set; }
        public DbSet<Enfoque> Enfoques { get; set; }
        public DbSet<RegistroCalificado> RegistrosCalificados { get; set; }
        public DbSet<EnfoqueRC> EnfoquesRCs { get; set; }
        public DbSet<Acreditacion> Acreditaciones { get; set; }
        public DbSet<AspectoNormativo> AspectosNormativos { get; set; }
        public DbSet<AnPrograma> AnProgramas { get; set; }
        public DbSet<DocenteDepartamento> DocenteDepartamentos { get; set; }
        public DbSet<Alianza> Alianzas { get; set; }
        public DbSet<Premio> Premios { get; set; }
        public DbSet<Pasantia> Pasantias { get; set; }
        public DbSet<ProgramaAC> ProgramaACs { get; set; }
        public DbSet<ActivAcademica> ActivAcademicas { get; set; }
        public DbSet<AaRc> AaRcs { get; set; }
        public DbSet<Aliado> Aliados { get; set; }
        public DbSet<AreaConocimiento> AreasConocimiento { get; set; }

        // Configuración adicional de las relaciones, llaves compuestas, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aliado>()
    .Property(a => a.Nit)
    .ValueGeneratedNever(); // No autogenerar Nit, se ingresará manualmente

            // Configuración de llaves compuestas
            modelBuilder.Entity<ProgramaCI>()
                .HasKey(pc => new { pc.ProgramaId, pc.CarInnovacionId });

            modelBuilder.Entity<ProgramaPE>()
                .HasKey(pp => new { pp.ProgramaId, pp.PracticaEstrategiaId });

            modelBuilder.Entity<EnfoqueRC>()
                .HasKey(er => new { er.EnfoqueId, er.RegistroCalificadoId });

            modelBuilder.Entity<AnPrograma>()
                .HasKey(ap => new { ap.AspectoNormativoId, ap.ProgramaId });

            modelBuilder.Entity<DocenteDepartamento>()
                .HasKey(dd => new { dd.DocenteId, dd.DepartamentoId });

            modelBuilder.Entity<Alianza>()
                .HasKey(a => new { a.AliadoId, a.DepartamentoId });

            modelBuilder.Entity<ProgramaAC>()
                .HasKey(pa => new { pa.ProgramaId, pa.AreaConocimientoId });

            modelBuilder.Entity<AaRc>()
                .HasKey(ar => new { ar.ActivAcademicaId, ar.RegistroCalificadoId });

            // Desactivar el borrado en cascada para evitar ciclos o múltiples caminos de cascada
            modelBuilder.Entity<AaRc>()
                .HasOne(ar => ar.RegistroCalificado)
                .WithMany(rc => rc.AaRcs)
                .HasForeignKey(ar => ar.RegistroCalificadoId)
                .OnDelete(DeleteBehavior.Restrict); // Desactivar cascada en AaRc

            // Si hay más relaciones con riesgo de ciclos, puedes añadir comportamientos similares.
        }
    }
}
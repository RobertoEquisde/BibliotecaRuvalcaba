using Biblioteca.Modelado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Datos
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //Modulo DDC
        public DbSet<CategoriaDDC> CategoriaDDC { get; set; }
        public DbSet<ClasificacionDDC> ClasificacionDDC { get; set; }

        // CATALOGO
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Libro_Autor> LibroAutor { get; set; }

        // Modulo Taxonamia
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Coleccion> Coleccion { get; set; }
        public DbSet<Libro_Coleccion> Libro_Coleccion { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }
  

        // Modulo Inventario
        public DbSet<Ejemplar> Ejemplar { get; set; }

        //Modulo Circulacion
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Historial_Prestamo> Historial_Prestamo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== Configuración de claves compuestas =====

        
            modelBuilder.Entity<Libro_Autor>()
                .HasKey(la => new { la.libro_id, la.autor_id, la.rol });

            modelBuilder.Entity<Libro_Coleccion>()
                .HasKey(lc => new { lc.libro_id, lc.coleccion_id });

            modelBuilder.Entity<Libro_Materia>()
            .HasKey(lm=>new{lm.libro_id,lm.materia_id});

            modelBuilder.Entity<Libro_Etiqueta>()
            .HasKey(le=>new{le.libro_id,le.etiqueta_id});
        }



    }
}

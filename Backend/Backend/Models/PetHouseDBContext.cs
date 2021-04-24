using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class PetHouseDBContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CategoriaMascota> CategoriaMascota { get; set; }
        public DbSet<TipoMascota> TipoMascota { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Hogar> Hogar { get; set; }
        public DbSet<TipoMultimedia> TipoMultimedia { get; set; }
        public DbSet<HogarMultimedia> HogarMultimedia { get; set; }
        public DbSet<EstatusReservacion> EstatusReservacion { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }

        public DbSet<ReservacionDetalle> ReservacionDetalle { get; set; }
        //public DbSet<EtapaReservacion> EtapaReservacion { get; set; }
        //public DbSet<HistorialReservacion> HistorialReservacion { get; set; }
        //public DbSet<HogarTipoMascota> HogarTipoMascota { get; set; }

        public PetHouseDBContext()
        {

        }

        public PetHouseDBContext(DbContextOptions<PetHouseDBContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaMascota>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.PaisId)
                .IsRequired();

                entity.HasOne(e => e.Pais)
                .WithMany()
                .IsRequired(true)
                .HasConstraintName("FK_Estado_Pais");
            });


            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.ID);


                entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.EstadoId)
                .IsRequired();

                entity.HasOne(e => e.Estado)
                .WithMany()
                .IsRequired(true)
                .HasConstraintName("FK_Ciudad_Estado");
            });
            
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .IsRequired();

                entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.NumExt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.NumInt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);


                entity.Property(e => e.CodigoPostal)
                .HasMaxLength(5)
                .IsRequired();

                entity.Property(e => e.NumeroTelefonico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.NumeroCelular)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Bloqueado)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValueSql("0");

                entity.Property(e => e.FechaUltimoAcceso)
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FechaUltimaActualizacion)
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.CiudadId)
                .IsRequired();

                entity.HasOne(e => e.Ciudad)
                .WithMany()
                .HasConstraintName("FK_Cliente_Ciudad");


            });



            modelBuilder.Entity<EstatusReservacion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();
            });

            //modelBuilder.Entity<EtapaReservacion>(entity =>
            //{
            //    entity.HasKey(e => e.EtrId);

            //    entity.Property(e => e.EtrNombre)
            //    .HasMaxLength(50)
            //    .IsUnicode(false)
            //    .IsRequired();
            //});

            //modelBuilder.Entity<HistorialReservacion>(entity =>
            //{
            //    entity.HasKey(e => new { e.HreReservacion, e.HreId });

            //    entity.Property(e => e.HreEtapa)
            //    .HasMaxLength(2)
            //    .IsUnicode(false)
            //    .IsRequired();

            //    entity.Property(e => e.HreFecha)
            //    .HasColumnType("datetime")
            //    .IsRequired()
            //    .HasDefaultValueSql("getdate()");

            //    entity.Property(e => e.HreComentarios)
            //    .HasMaxLength(500)
            //    .IsUnicode(false)
            //    .IsRequired();

            //    entity.HasOne(e => e.Reservacion)
            //    .WithMany(f => f.HistorialReservacion)
            //    .HasForeignKey("FK_Historial_Reservacion");
            //});

            modelBuilder.Entity<Hogar>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ClienteId)
                .HasMaxLength(10)
                .IsRequired();

                entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CostoPorNoche)
                .HasColumnType("decimal")
                .HasMaxLength(12)
                .IsRequired();

                entity.Property(e => e.Capacidad)
                .HasColumnType("int")
                .HasMaxLength(2)
                .IsRequired();

                entity.Property(e => e.CuentaConMascotas)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .IsRequired();

                entity.Property(e => e.Publicado)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .HasDefaultValueSql("0");

                entity.Property(e => e.Disponible)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .HasDefaultValueSql("0");

                entity.Property(e => e.Pausado)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .HasDefaultValueSql("0");

                entity.HasOne<Cliente>(e => e.Cliente)
                .WithMany()
                .HasConstraintName("FK_Hogar_Cliente");

            });

            modelBuilder.Entity<TipoMultimedia>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<HogarMultimedia>(entity =>
            {
                entity.HasKey(e => new { e.HogarId, e.Id });

                entity.Property(e => e.HogarId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Extension)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.TipoMultimediaId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne<Hogar>(e => e.Hogar)
                .WithMany()
                .HasConstraintName("FK_Hogar_Multimedia");

                entity.HasOne<TipoMultimedia>(e => e.TipoMultimedia)
                .WithMany()
                .HasConstraintName("FK_Tipo_Multimedia");
            });

            //modelBuilder.Entity<HogarTipoMascota>(entity =>
            //{
            //    entity.HasKey(e => new { e.HtmHogar, e.HtmTipoMascota });

            //    entity.Property(e => e.HtmTipoMascota)
            //    .HasMaxLength(2)
            //    .IsUnicode(false)
            //    .IsRequired();

            //    entity.HasOne<Hogar>(e => e.Hogar)
            //    .WithMany(f => f.HogarTipoMascota)
            //    .HasForeignKey("FK_HogarTipoMascota_TipoMascota");

            //});

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.ID );

                entity.Property(e => e.ClienteId)
                .HasMaxLength(10)
                .IsRequired();

                entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Edad)
                .HasMaxLength(2)
                .IsRequired();

                entity.Property(e => e.TipoMascotaId)
                .HasMaxLength(1)
                .IsRequired();

                entity.Property(e => e.CategoriaMascotaId)
                .HasMaxLength(1)
                .IsRequired();

                entity.Property(e => e.Imagen)
                .HasMaxLength(65535)
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.CartillaPdf)
                .HasMaxLength(65535)
                .IsUnicode(false)
                .IsRequired(false);

                entity.HasOne<Cliente>(e => e.Cliente)
                .WithMany()
                .HasConstraintName("FK_Mascota_Cliente");

                entity.HasOne<TipoMascota>(e => e.TipoMascota)
                .WithMany()
                .HasConstraintName("FK_Mascota_Tipo");

                entity.HasOne<CategoriaMascota>(e => e.CategoriaMascota)
                .WithMany()
                .HasConstraintName("FK_Mascota_Categoria");

            });

            modelBuilder.Entity<TipoMascota>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ClienteId)
                .IsRequired();

                entity.Property(e => e.HogarId)
                .IsRequired();


                entity.Property(e => e.EstatusReservacionId)
                .IsRequired();

                entity.Property(e => e.FechaEntrada)
                .HasColumnType("datetime")
                .IsRequired();

                entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .IsRequired();

                entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal")
                .IsRequired();

                entity.Property(e => e.RecibeAlimento)
                .HasColumnType("bit")
                .IsRequired();

                entity.Property(e => e.DescripcionAlimento)
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.ComentariosCliente)
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .IsRequired(false)
                .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Cliente)
                .WithMany()
                .HasConstraintName("FK_Reservacion_Cliente");

                entity.HasOne(e => e.Hogar)
                .WithMany()
                .HasConstraintName("FK_Reservacion_Hogar");

                entity.HasOne(e => e.EstatusReservacion)
                .WithMany()
                .HasConstraintName("FK_Reservacion_Estatus");


            });

            modelBuilder.Entity<ReservacionDetalle>(entity =>
            {
                entity.HasKey(e => new { e.ReservacionId, e.MascotaId });
                
                entity.HasOne(e => e.Reservacion)
                .WithMany()
                .HasConstraintName("FK_RDetalle_Reservacion");

                entity.HasOne(e => e.Mascota)
                .WithMany()
                .HasConstraintName("FK_RDetalle_Mascota");
            });


        }

    }
}

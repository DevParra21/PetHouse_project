using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class PetHouseDBContext : DbContext
    {
        public DbSet<CategoriaMascota> CategoriaMascota { get; set; }
        public DbSet<Ciudad>Ciudad { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<EstatusReservacion> EstatusReservacion { get; set; }
        public DbSet<EtapaReservacion> EtapaReservacion { get; set; }
        public DbSet<HistorialReservacion> HistorialReservacion { get; set; }
        public DbSet<Hogar> Hogar { get; set; }
        public DbSet<HogarMultimedia> HogarMultimedia { get; set; }
        public DbSet<HogarTipoMascota> HogarTipoMascota { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<TipoMascota> TipoMascota { get; set; }

        public PetHouseDBContext()
        {

        }

        public PetHouseDBContext(DbContextOptions<PetHouseDBContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaMascota>(entity =>
            {
                entity.HasKey(e => e.CmaId);

                entity.Property(e => e.CmaNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => new { e.CiuPais, e.CiuEstado, e.CiuId });

                entity.Property(e => e.CiuNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
            });
            
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.Property(e => e.CliNombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliApellidoPaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliApellidoMaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliFechaNacimiento)
                .HasColumnType("date")
                .IsRequired();

                entity.Property(e => e.CliCorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliContrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliNumeroTelefonico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.CliNumeroCelular)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.CliBloqueado)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValueSql("0");

                entity.Property(e => e.CliFechaUltimoAcceso)
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.CliFechaAlta)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CliFechaUltimaActualizacion)
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.CliFechaBaja)
                .HasColumnType("datetime")
                .IsRequired(false);

            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => new { e.EstPais, e.EstId });

                entity.Property(e => e.EstNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<EstatusReservacion>(entity =>
            {
                entity.HasKey(e => e.EreId);

                entity.Property(e => e.EreNombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();
            });
            
            modelBuilder.Entity<EtapaReservacion>(entity =>
            {
                entity.HasKey(e => e.EtrId);

                entity.Property(e => e.EtrNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });
            
            modelBuilder.Entity<HistorialReservacion>(entity =>
            {
                entity.HasKey(e => new { e.HreReservacion, e.HreId });

                entity.Property(e => e.HreEtapa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HreFecha)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

                entity.Property(e => e.HreComentarios)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne(e => e.Reservacion)
                .WithMany(f => f.HistorialReservacion)
                .HasForeignKey("FK_Historial_Reservacion");
            });

            modelBuilder.Entity<Hogar>(entity =>
            {
                entity.HasKey(e => e.HogId);

                entity.Property(e => e.HogCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HogDescripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HogCostoPorNoche)
                .HasColumnType("double")
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HogCapacidad)
                .HasColumnType("int")
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HogCuentaConMascotas)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .IsRequired();

                entity.Property(e => e.HogPublicado)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsRequired()
                .HasDefaultValueSql("0");

                entity.Property(e => e.HogDisponible)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsRequired()
                .HasDefaultValueSql("0");

                entity.Property(e => e.HogPausado)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsRequired()
                .HasDefaultValueSql("0");

                entity.HasOne<Cliente>(e => e.Cliente)
                .WithMany(f => f.Hogar)
                .HasForeignKey("FK_Hogar_Cliente");
            });

            modelBuilder.Entity<HogarMultimedia>(entity =>
            {
                entity.HasKey(e => new { e.HmuHogar, e.HmuId });

                entity.Property(e => e.HmuHogar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HmuNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HmuExtension)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.HmuTipo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne<Hogar>(e => e.Hogar)
                .WithMany(f => f.HogarMultimedia)
                .HasForeignKey("FK_Hogar_Multimedia");
            });
            
            modelBuilder.Entity<HogarTipoMascota>(entity =>
            {
                entity.HasKey(e => new { e.HtmHogar, e.HtmTipoMascota });

                entity.Property(e => e.HtmTipoMascota)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne<Hogar>(e => e.Hogar)
                .WithMany(f => f.HogarTipoMascota)
                .HasForeignKey("FK_HogarTipoMascota_TipoMascota");

            });
            
            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => new { e.MasCliente, e.MasId });

                entity.Property(e => e.MasCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasNombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasEdad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasTipoMascota)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasCategoriaMascota)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasImagen)
                .HasMaxLength(65535)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.MasCartillaPdf)
                .HasMaxLength(65535)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne<Cliente>(e => e.Cliente)
                .WithMany(f => f.Mascota)
                .HasForeignKey("FK_Mascota_Cliente");

            });
            
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaiId);

                entity.Property(e => e.PaiNombre)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<TipoMascota>(entity =>
            {
                entity.HasKey(e => e.TmaId);

                entity.Property(e => e.TmaNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.Property(e => e.ResCliente)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResHogar)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResMascota)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResEstatus)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResFechaEntrada)
                .HasColumnType("datetime")
                .IsRequired();

                entity.Property(e => e.ResFechaSalida)
                .HasColumnType("datetime")
                .IsRequired();

                entity.Property(e => e.ResMontoTotal)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResRecibeAlimento)
                .HasColumnType("bit")
                .IsRequired();

                entity.Property(e => e.ResDescripcionAlimento)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.ResComentariosCliente)
                .IsUnicode(false)
                .IsRequired();

                entity.HasOne(e => e.Cliente)
                .WithMany(f => f.Reservacion)
                .HasForeignKey("FK_Reservacion_Cliente"); //Si no funciona, cambiar por HasConstraint

                entity.HasOne(e => e.Mascota)
                .WithMany(f => f.Reservacion)
                .HasForeignKey("Nombre de Constraint");

                entity.HasOne(e => e.Hogar)
                .WithMany(f => f.Reservacion)
                .HasForeignKey("FK_Reservacion_Hogar");

                entity.HasOne(e => e.EstatusReservacion)
                .WithMany(f => f.Reservacion)
                .HasForeignKey("FK_Reservacion_Estatus");

            });


        }

    }
}

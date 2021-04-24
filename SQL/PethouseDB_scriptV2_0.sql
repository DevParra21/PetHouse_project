/*
	Equipo número 7.

	Integrantes:
		Escudero Parra Patricio Eduardo - 1607641
		Gámez Guerrero Edgar Orlando - 1837511
	-------------------------------------------------
	Actualización de Base de Datos v2.0
*/

/*	Query #1
 *
 *  Descripción: DROP y CREATE de nuevo diseño de Base de Datos. Creación de Base de Datos [PethouseDB].
 */
USE [PetHouseDB]
GO
ALTER TABLE [dbo].[ReservacionDetalle] DROP CONSTRAINT [FK_RDetalle_Reservacion]
GO
ALTER TABLE [dbo].[ReservacionDetalle] DROP CONSTRAINT [FK_RDetalle_Mascota]
GO
ALTER TABLE [dbo].[Reservacion] DROP CONSTRAINT [FK_Reservacion_Hogar]
GO
ALTER TABLE [dbo].[Reservacion] DROP CONSTRAINT [FK_Reservacion_Estatus]
GO
ALTER TABLE [dbo].[Reservacion] DROP CONSTRAINT [FK_Reservacion_Cliente]
GO
ALTER TABLE [dbo].[Mascota] DROP CONSTRAINT [FK_Mascota_Tipo]
GO
ALTER TABLE [dbo].[Mascota] DROP CONSTRAINT [FK_Mascota_Cliente]
GO
ALTER TABLE [dbo].[Mascota] DROP CONSTRAINT [FK_Mascota_Categoria]
GO
ALTER TABLE [dbo].[HogarMultimedia] DROP CONSTRAINT [FK_Tipo_Multimedia]
GO
ALTER TABLE [dbo].[HogarMultimedia] DROP CONSTRAINT [FK_Hogar_Multimedia]
GO
ALTER TABLE [dbo].[Hogar] DROP CONSTRAINT [FK_Hogar_Cliente]
GO
ALTER TABLE [dbo].[Estado] DROP CONSTRAINT [FK_Estado_Pais]
GO
ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [FK_Cliente_Ciudad]
GO
ALTER TABLE [dbo].[Ciudad] DROP CONSTRAINT [FK_Ciudad_Estado]
GO
ALTER TABLE [dbo].[Reservacion] DROP CONSTRAINT [DF__Reservaci__Fecha__7B5B524B]
GO
ALTER TABLE [dbo].[Reservacion] DROP CONSTRAINT [DF__Reservaci__Estat__7A672E12]
GO
ALTER TABLE [dbo].[Mascota] DROP CONSTRAINT [DF__Mascota__FechaAl__47DBAE45]
GO
ALTER TABLE [dbo].[Hogar] DROP CONSTRAINT [DF__Hogar__FechaAlta__5070F446]
GO
ALTER TABLE [dbo].[Hogar] DROP CONSTRAINT [DF__Hogar__Pausado__4F7CD00D]
GO
ALTER TABLE [dbo].[Hogar] DROP CONSTRAINT [DF__Hogar__Disponibl__4E88ABD4]
GO
ALTER TABLE [dbo].[Hogar] DROP CONSTRAINT [DF__Hogar__Publicado__4D94879B]
GO
ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [DF__Cliente__FechaAl__403A8C7D]
GO
ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [DF__Cliente__Bloquea__3F466844]
GO
ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [UQ__Cliente__531402F387C32DB5]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoMultimedia]') AND type in (N'U'))
DROP TABLE [dbo].[TipoMultimedia]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoMascota]') AND type in (N'U'))
DROP TABLE [dbo].[TipoMascota]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReservacionDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[ReservacionDetalle]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservacion]') AND type in (N'U'))
DROP TABLE [dbo].[Reservacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pais]') AND type in (N'U'))
DROP TABLE [dbo].[Pais]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mascota]') AND type in (N'U'))
DROP TABLE [dbo].[Mascota]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HogarMultimedia]') AND type in (N'U'))
DROP TABLE [dbo].[HogarMultimedia]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hogar]') AND type in (N'U'))
DROP TABLE [dbo].[Hogar]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstatusReservacion]') AND type in (N'U'))
DROP TABLE [dbo].[EstatusReservacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estado]') AND type in (N'U'))
DROP TABLE [dbo].[Estado]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ciudad]') AND type in (N'U'))
DROP TABLE [dbo].[Ciudad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriaMascota]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriaMascota]
GO
USE [master]
GO
DROP DATABASE [PetHouseDB]
GO
CREATE DATABASE [PetHouseDB]
 CONTAINMENT = NONE
GO
ALTER DATABASE [PetHouseDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetHouseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetHouseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetHouseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetHouseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetHouseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetHouseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetHouseDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PetHouseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetHouseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetHouseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetHouseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetHouseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetHouseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetHouseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetHouseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetHouseDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PetHouseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetHouseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetHouseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetHouseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetHouseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetHouseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetHouseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetHouseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PetHouseDB] SET  MULTI_USER 
GO
ALTER DATABASE [PetHouseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetHouseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetHouseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetHouseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetHouseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetHouseDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PetHouseDB] SET QUERY_STORE = OFF
GO
USE [PetHouseDB]
GO

/*	Query #2
 *	Descripción: Rediseño de Tablas [CategoriaMascota].
 *	Catálogo de la categoría a la que pertenece la mascota.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaMascota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*	Query #3
 *	Descripción: Rediseño de Tablas [Ciudad].
 *	Catálogo de Ciudades.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #4
 *	Descripción: Rediseño de Tablas [Cliente].
 *	Guardará la información de los Clientes que se registren en la aplicación. 
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[ApellidoPaterno] [varchar](25) NOT NULL,
	[ApellidoMaterno] [varchar](25) NULL,
	[FechaNacimiento] [date] NULL,
	[Calle] [varchar](100) NULL,
	[NumExt] [varchar](10) NULL,
	[NumInt] [varchar](10) NULL,
	[CodigoPostal] [int] NULL,
	[CiudadId] [int] NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[NumeroTelefonico] [varchar](10) NULL,
	[NumeroCelular] [varchar](10) NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[FechaUltimoAcceso] [datetime] NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaUltimaActualizacion] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #5
 *	Descripción: Rediseño de Tablas [Estado].
 *	Catálogo de Estados.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaisId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #6
 *	Descripción: Rediseño de Tablas [EstatusReservacion].
 *	Catálogo de los estatus posibles en una reservación de acuerdo al momento en el que se encuentre.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusReservacion](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #7
 *	Descripción: Rediseño de Tablas [Hogar].
 *	Guardará la información de los hogares registrados por los clientes al decidir ser anfitriones.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hogar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[CostoPorNoche] [numeric](12, 2) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[CuentaConMascotas] [bit] NOT NULL,
	[Publicado] [bit] NOT NULL,
	[Disponible] [bit] NOT NULL,
	[Pausado] [bit] NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaUltimaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #8
 *	Descripción: Rediseño de Tablas [HogarMultimedia].
 *	Guardará la información multimedia (imágenes y video) del Hogar registrado.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HogarMultimedia](
	[HogarId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[TipoMultimediaId] [int] NOT NULL,
	[Extension] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HogarId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #9
 *	Descripción: Rediseño de Tablas [Mascota].
 *	Catálogo de las mascotas registradas por los clientes.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[TipoMascotaId] [int] NOT NULL,
	[CategoriaMascotaId] [int] NOT NULL,
	[Imagen] [varchar](max) NULL,
	[CartillaPdf] [varchar](max) NULL,
	[FechaAlta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/*	Query #10
 *	Descripción: Rediseño de Tablas [Pais].
 *	Catálogo de Países.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #11
 *	Descripción: Rediseño de Tablas [Reservacion].
 *	Guardará la información de la reservación del cliente, qué mascota tendrá el servicio y en qué hogar se prestará este servicio.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[HogarId] [int] NOT NULL,
	[EstatusReservacionId] [int] NOT NULL,
	[FechaEntrada] [datetime] NOT NULL,
	[FechaSalida] [datetime] NOT NULL,
	[MontoTotal] [numeric](12, 2) NOT NULL,
	[RecibeAlimento] [bit] NULL,
	[DescripcionAlimento] [varchar](500) NULL,
	[ComentariosCliente] [varchar](500) NULL,
	[FechaAlta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #12
	Descripción: Creación de Tablas [ReservacionDetalle] - Tabla que no se tenía contemplada en la versión anterior.
	Guardará la información del detalle reservación del cliente, qué mascota tendrá el servicio y a qué reservación está asociado*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservacionDetalle](
	[ReservacionId] [int] NOT NULL,
	[MascotaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservacionId] ASC,
	[MascotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #13
 *	Descripción: Rediseño de Tablas [TipoMascota].
 *	Popular el catálogo de Tipos de Mascotas.
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMascota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*	Query #14
	Descripción: Rediseño de Tablas [TipoMultimedia].
	Catálogo donde se define el tipo de Multimedia (imágenes o videos).*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMultimedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/* 
 * Query #15
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo CategoriaMascota
 */
SET IDENTITY_INSERT [dbo].[CategoriaMascota] ON 
GO
INSERT [dbo].[CategoriaMascota] ([Id], [Nombre]) VALUES (1, N'Tiny')
GO
INSERT [dbo].[CategoriaMascota] ([Id], [Nombre]) VALUES (2, N'Pequeño')
GO
INSERT [dbo].[CategoriaMascota] ([Id], [Nombre]) VALUES (3, N'Mediano')
GO
INSERT [dbo].[CategoriaMascota] ([Id], [Nombre]) VALUES (4, N'Grande')
GO
INSERT [dbo].[CategoriaMascota] ([Id], [Nombre]) VALUES (5, N'Gigante')
GO
SET IDENTITY_INSERT [dbo].[CategoriaMascota] OFF
GO
/* 
 * Query #16
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Ciudad
 */
SET IDENTITY_INSERT [dbo].[Ciudad] ON 
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (1, 1, N'Aguascalientes')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (2, 1, N'Asientos')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (3, 1, N'Calvillo')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (4, 1, N'Cosío')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (5, 1, N'Jesús María')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (6, 1, N'Pabellón de Arteaga')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (7, 1, N'Rincón de Romos')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (8, 1, N'San José de Gracia')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (9, 1, N'Tepezalá')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (10, 1, N'Palo Alto')
GO
INSERT [dbo].[Ciudad] ([Id], [EstadoId], [Nombre]) VALUES (11, 1, N'San Francisco de los Romo')
GO
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
GO
/* 
 * Query #17
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Cliente
 */
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (1, N'Pato', N'Escudero', N'Parra', CAST(N'1992-03-21' AS Date), N'Nombre de Calle', N'3333', N'10', 67190, 1, N'patricio.escuderoprr@uanl.edu.mx', N'Pato2103', N'9221056183', N'9221056183', 0, NULL, CAST(N'2021-04-23T04:08:42.080' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (2, N'Daniel', N'Ayala', N'Parra', CAST(N'1992-03-21' AS Date), N'Nombre de Calle', N'3333', N'10', 67190, 1, N'daniel.ayalaprr@uanl.edu.mx', N'Pato2103', N'9221056183', N'9221056183', 1, NULL, CAST(N'2021-04-23T11:00:24.637' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (3, N'David', N'Perez', N'Parra', CAST(N'2001-04-23' AS Date), N'Nombre de Calle', N'10-A', N'3B', 67160, 5, N'davidperez@hotmail.com', N'contrasenaSegura', N'811283732', N'811273732', 0, NULL, CAST(N'2021-04-23T17:44:37.263' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (4, N'Mari', N'Posa', N'Tray', CAST(N'1994-04-23' AS Date), N'nombreCalle', N'11', N'12', 40000, 3, N'mari.posa@outlook.com', N'abcde1234', N'12345678', N'87654321', 0, NULL, CAST(N'2021-04-23T18:03:45.793' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (5, N'Enrique', N'Tolentino', N'García', CAST(N'1998-04-24' AS Date), N'Nombre de la Calle', N'100', N'A', 60900, 5, N'enriquetolentino@gmail.com', N'et2021!', N'9220193493', N'18282393', 0, NULL, CAST(N'2021-04-23T21:34:44.890' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (6, N'Ariel', N'Parra', N'Guzmán', CAST(N'2000-04-24' AS Date), N'Nombre de Calle', N'1000', NULL, 678000, 4, N'arielparra@yahoo.com.mx', N'abcde123', N'8112833828', N'8112833828', 0, NULL, CAST(N'2021-04-24T02:33:13.223' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (7, N'Dany', N'Villarreal', N'Parra', CAST(N'1998-04-24' AS Date), N'Nombre Calle', N'100', NULL, 50030, 2, N'dv21@hotmail.com', N'abc123', N'811283832', N'811283383', 0, NULL, CAST(N'2021-04-24T06:21:58.207' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Calle], [NumExt], [NumInt], [CodigoPostal], [CiudadId], [CorreoElectronico], [Contrasena], [NumeroTelefonico], [NumeroCelular], [Bloqueado], [FechaUltimoAcceso], [FechaAlta], [FechaUltimaActualizacion], [FechaBaja]) VALUES (8, N'Jesus', N'Alfonso', N'Perez', CAST(N'2000-04-24' AS Date), N'Calle', N'110-A', NULL, 12345, 4, N'pato@hotmail.com', N'contrase1234', N'81123833', N'9993393', 0, NULL, CAST(N'2021-04-24T14:23:50.023' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
/* 
 * Query #18
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo CategoriaMascota
 */
SET IDENTITY_INSERT [dbo].[Estado] ON 
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (1, 52, N'Aguascalientes')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (2, 52, N'Baja California')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (3, 52, N'Baja California Sur')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (4, 52, N'Campeche')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (5, 52, N'Coahuila de Zaragoza')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (6, 52, N'Colima')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (7, 52, N'Chiapas')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (8, 52, N'Chihuahua')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (9, 52, N'Distrito Federal')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (10, 52, N'Durango')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (11, 52, N'Guanajuato')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (12, 52, N'Guerrero')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (13, 52, N'Hidalgo')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (14, 52, N'Jalisco')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (15, 52, N'México')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (16, 52, N'Michoacán de Ocampo')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (17, 52, N'Morelos')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (18, 52, N'Nayarit')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (19, 52, N'Nuevo León')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (20, 52, N'Oaxaca de Juárez')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (21, 52, N'Puebla')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (22, 52, N'Querétaro')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (23, 52, N'Quintana Roo')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (24, 52, N'San Luis Potosí')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (25, 52, N'Sinaloa')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (26, 52, N'Sonora')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (27, 52, N'Tabasco')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (28, 52, N'Tamaulipas')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (29, 52, N'Tlaxcala')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (30, 52, N'Veracruz de Ignacio de la Llave')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (31, 52, N'Yucatán')
GO
INSERT [dbo].[Estado] ([Id], [PaisId], [Nombre]) VALUES (32, 52, N'Zacatecas')
GO
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
/* 
 * Query #19
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo EstatusReservacion
 */
INSERT [dbo].[EstatusReservacion] ([Id], [Nombre]) VALUES (1, N'Pendiente')
GO
INSERT [dbo].[EstatusReservacion] ([Id], [Nombre]) VALUES (2, N'Aceptada')
GO
INSERT [dbo].[EstatusReservacion] ([Id], [Nombre]) VALUES (3, N'En Proceso')
GO
INSERT [dbo].[EstatusReservacion] ([Id], [Nombre]) VALUES (4, N'Terminada')
GO
INSERT [dbo].[EstatusReservacion] ([Id], [Nombre]) VALUES (99, N'Cancelada')
GO
/* 
 * Query #20
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Hogar
 */
SET IDENTITY_INSERT [dbo].[Hogar] ON 
GO
INSERT [dbo].[Hogar] ([Id], [ClienteId], [Descripcion], [CostoPorNoche], [Capacidad], [CuentaConMascotas], [Publicado], [Disponible], [Pausado], [FechaAlta], [FechaUltimaActualizacion]) VALUES (2, 1, N'Esta es otra descripción', CAST(139.99 AS Numeric(12, 2)), 2, 1, 1, 0, 0, NULL, NULL)
GO
INSERT [dbo].[Hogar] ([Id], [ClienteId], [Descripcion], [CostoPorNoche], [Capacidad], [CuentaConMascotas], [Publicado], [Disponible], [Pausado], [FechaAlta], [FechaUltimaActualizacion]) VALUES (3, 4, N'Casa con Patio grande para un máximo de 5 perros', CAST(299.99 AS Numeric(12, 2)), 5, 0, 0, 1, 1, NULL, NULL)
GO
INSERT [dbo].[Hogar] ([Id], [ClienteId], [Descripcion], [CostoPorNoche], [Capacidad], [CuentaConMascotas], [Publicado], [Disponible], [Pausado], [FechaAlta], [FechaUltimaActualizacion]) VALUES (4, 1, N'segunda descripcion', CAST(129.99 AS Numeric(12, 2)), 2, 0, 0, 1, 1, CAST(N'2021-04-24T11:29:06.550' AS DateTime), NULL)
GO
INSERT [dbo].[Hogar] ([Id], [ClienteId], [Descripcion], [CostoPorNoche], [Capacidad], [CuentaConMascotas], [Publicado], [Disponible], [Pausado], [FechaAlta], [FechaUltimaActualizacion]) VALUES (5, 3, N'Prueba de actualización', CAST(300.00 AS Numeric(12, 2)), 2, 1, 1, 1, 1, CAST(N'2021-04-24T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Hogar] OFF
GO
/* 
 * Query #21
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo HogarMultimedia
 */
INSERT [dbo].[HogarMultimedia] ([HogarId], [Id], [Nombre], [TipoMultimediaId], [Extension]) VALUES (4, 1, N'imgMascota.jpg', 1, N'jpg')
GO
INSERT [dbo].[HogarMultimedia] ([HogarId], [Id], [Nombre], [TipoMultimediaId], [Extension]) VALUES (5, 1, N'foto02032.png', 1, N'png')
GO
/* 
 * Query #22
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Mascota
 */
SET IDENTITY_INSERT [dbo].[Mascota] ON 
GO
INSERT [dbo].[Mascota] ([Id], [ClienteId], [Nombre], [Edad], [TipoMascotaId], [CategoriaMascotaId], [Imagen], [CartillaPdf], [FechaAlta]) VALUES (3, 1, N'Shadowprice', 5, 2, 3, NULL, NULL, NULL)
GO
INSERT [dbo].[Mascota] ([Id], [ClienteId], [Nombre], [Edad], [TipoMascotaId], [CategoriaMascotaId], [Imagen], [CartillaPdf], [FechaAlta]) VALUES (4, 2, N'Rex', 2, 3, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Mascota] ([Id], [ClienteId], [Nombre], [Edad], [TipoMascotaId], [CategoriaMascotaId], [Imagen], [CartillaPdf], [FechaAlta]) VALUES (5, 1, N'EmmaW', 3, 1, 4, NULL, NULL, CAST(N'2021-04-24T14:44:04.497' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Mascota] OFF
GO
/* 
 * Query #23
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Pais
 */
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (52, N'México')
GO
/* 
 * Query #24
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo Reservacion
 */
SET IDENTITY_INSERT [dbo].[Reservacion] ON 
GO
INSERT [dbo].[Reservacion] ([Id], [ClienteId], [HogarId], [EstatusReservacionId], [FechaEntrada], [FechaSalida], [MontoTotal], [RecibeAlimento], [DescripcionAlimento], [ComentariosCliente], [FechaAlta]) VALUES (2, 1, 3, 1, CAST(N'2021-05-01T08:00:00.000' AS DateTime), CAST(N'2021-05-05T08:00:00.000' AS DateTime), CAST(1999.95 AS Numeric(12, 2)), 0, NULL, N'Comentarios del cliente', NULL)
GO
SET IDENTITY_INSERT [dbo].[Reservacion] OFF
GO
/* 
 * Query #25
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo TipoMascota
 */
SET IDENTITY_INSERT [dbo].[TipoMascota] ON 
GO
INSERT [dbo].[TipoMascota] ([Id], [Nombre]) VALUES (1, N'Perros')
GO
INSERT [dbo].[TipoMascota] ([Id], [Nombre]) VALUES (2, N'Gatos')
GO
INSERT [dbo].[TipoMascota] ([Id], [Nombre]) VALUES (3, N'Peces')
GO
INSERT [dbo].[TipoMascota] ([Id], [Nombre]) VALUES (4, N'Otros')
GO
SET IDENTITY_INSERT [dbo].[TipoMascota] OFF
GO
/* 
 * Query #26
 * INSERTS DE PRUEBA DE CATÁLOGOS: Catálogo TipoMultimedia
 */
SET IDENTITY_INSERT [dbo].[TipoMultimedia] ON 
GO
INSERT [dbo].[TipoMultimedia] ([Id], [Nombre]) VALUES (1, N'Imágenes')
GO
INSERT [dbo].[TipoMultimedia] ([Id], [Nombre]) VALUES (2, N'Video')
GO
INSERT [dbo].[TipoMultimedia] ([Id], [Nombre]) VALUES (3, N'Audio')
GO
SET IDENTITY_INSERT [dbo].[TipoMultimedia] OFF
GO
SET ANSI_PADDING ON
GO
/* 
 * Query #27
 * CONFIGURACIÓN DE DEFAULTS: Tabla Cliente
 */
ALTER TABLE [dbo].[Cliente] ADD UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((0)) FOR [Bloqueado]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [FechaAlta]
GO
/* 
 * Query #28
 * CONFIGURACIÓN DE DEFAULTS: Tabla Hogar
 */
ALTER TABLE [dbo].[Hogar] ADD  DEFAULT ((0)) FOR [Publicado]
GO
ALTER TABLE [dbo].[Hogar] ADD  DEFAULT ((0)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Hogar] ADD  DEFAULT ((0)) FOR [Pausado]
GO
ALTER TABLE [dbo].[Hogar] ADD  DEFAULT (getdate()) FOR [FechaAlta]
GO
/* 
 * Query #29
 * CONFIGURACIÓN DE DEFAULTS: Tabla Mascota
 */
ALTER TABLE [dbo].[Mascota] ADD  DEFAULT (getdate()) FOR [FechaAlta]
GO
ALTER TABLE [dbo].[Reservacion] ADD  DEFAULT ((1)) FOR [EstatusReservacionId]
GO
ALTER TABLE [dbo].[Reservacion] ADD  DEFAULT (getdate()) FOR [FechaAlta]
GO
/* 
 * Query #30
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Ciudad
 */
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Estado]
GO
/* 
 * Query #31
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Cliente
 */
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Ciudad] FOREIGN KEY([CiudadId])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Ciudad]
GO
/* 
 * Query #32
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Cliente
 */
ALTER TABLE [dbo].[Estado]  WITH CHECK ADD  CONSTRAINT [FK_Estado_Pais] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[Estado] CHECK CONSTRAINT [FK_Estado_Pais]
GO
/* 
 * Query #33
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Cliente
 */
ALTER TABLE [dbo].[Hogar]  WITH CHECK ADD  CONSTRAINT [FK_Hogar_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Hogar] CHECK CONSTRAINT [FK_Hogar_Cliente]
GO
/* 
 * Query #34
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Cliente
 */
ALTER TABLE [dbo].[HogarMultimedia]  WITH CHECK ADD  CONSTRAINT [FK_Hogar_Multimedia] FOREIGN KEY([HogarId])
REFERENCES [dbo].[Hogar] ([Id])
GO
ALTER TABLE [dbo].[HogarMultimedia] CHECK CONSTRAINT [FK_Hogar_Multimedia]
GO
ALTER TABLE [dbo].[HogarMultimedia]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Multimedia] FOREIGN KEY([TipoMultimediaId])
REFERENCES [dbo].[TipoMultimedia] ([Id])
GO
ALTER TABLE [dbo].[HogarMultimedia] CHECK CONSTRAINT [FK_Tipo_Multimedia]
GO
/* 
 * Query #35
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Mascota
 */
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Categoria] FOREIGN KEY([CategoriaMascotaId])
REFERENCES [dbo].[CategoriaMascota] ([Id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Categoria]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Cliente]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Tipo] FOREIGN KEY([TipoMascotaId])
REFERENCES [dbo].[TipoMascota] ([Id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Tipo]
GO
/* 
 * Query #36
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Reservacion
 */
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Cliente]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Estatus] FOREIGN KEY([EstatusReservacionId])
REFERENCES [dbo].[EstatusReservacion] ([Id])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Estatus]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Hogar] FOREIGN KEY([HogarId])
REFERENCES [dbo].[Hogar] ([Id])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Hogar]
GO
/* 
 * Query #37
 * CREACIÓN DE CONSTRAINTS/FOREIGN KEYS: Tabla Cliente
 */
ALTER TABLE [dbo].[ReservacionDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RDetalle_Mascota] FOREIGN KEY([MascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[ReservacionDetalle] CHECK CONSTRAINT [FK_RDetalle_Mascota]
GO
ALTER TABLE [dbo].[ReservacionDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RDetalle_Reservacion] FOREIGN KEY([ReservacionId])
REFERENCES [dbo].[Reservacion] ([Id])
GO
ALTER TABLE [dbo].[ReservacionDetalle] CHECK CONSTRAINT [FK_RDetalle_Reservacion]
GO
USE [master]
GO
ALTER DATABASE [PetHouseDB] SET  READ_WRITE 
GO

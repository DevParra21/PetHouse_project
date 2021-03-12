/*
	Equipo n�mero 7.

	Integrantes:
		Escudero Parra Patricio Eduardo - 1607641
		G�mez Guerrero Edgar Orlando - 1837511
*/

/*	Query #1
	Descripci�n: Creaci�n de Base de Datos [PethouseDB].*/
CREATE DATABASE PetHouseDB;
GO

/*	Query #2
	Descripci�n: Uso de Base de Datos [PethouseDB] para correr script sobre ella.*/
USE PetHouseDB;
GO;

/*	Query #3
	Descripci�n: Creaci�n de Tablas [Pais].
	Cat�logo de Pa�ses.*/
CREATE TABLE Pais(
	PaiId NUMERIC(3,0) NOT NULL,
	PaiNombre VARCHAR(50) NOT NULL,
	PRIMARY KEY(PaiId)
);
GO
/*	Query #4
	Descripci�n: Insert en Tablas [Pais].
	Popular cat�logo de Pa�ses.*/
INSERT INTO Pais(PaiId, PaiNombre) VALUES(1, 'M�xico');
GO
/*	Query #5
	Descripci�n: Creaci�n de Tablas [Estado].
	Cat�logo de Estados.*/
CREATE TABLE Estado(
	EstId NUMERIC(2,0) NOT NULL,
	EstPais NUMERIC(3,0) NOT NULL,
	EstNombre VARCHAR(50) NOT NULL
	PRIMARY KEY(EstId),
	CONSTRAINT FK_Estado_Pais FOREIGN KEY (EstPais) REFERENCES Pais(PaiId)
);
GO
/*	Query #6
	Descripci�n: Insert en Tablas [Estado].
	Popular cat�logo de Estados.*/
INSERT INTO Estado (EstId, EstPais, EstNombre) VALUES
(1,  1,'Aguascalientes'),
(2,  1,'Baja California'),
(3,  1,'Baja California Sur'),
(4,  1,'Campeche'),
(5,  1,'Coahuila de Zaragoza'),
(6,  1,'Colima'),
(7,  1,'Chiapas'),
(8,  1,'Chihuahua'),
(9,  1,'Distrito Federal'),
(10, 1, 'Durango'),
(11, 1, 'Guanajuato'),
(12, 1, 'Guerrero'),
(13, 1, 'Hidalgo'),
(14, 1, 'Jalisco'),
(15, 1, 'M�xico'),
(16, 1, 'Michoac�n de Ocampo'),
(17, 1, 'Morelos'),
(18, 1, 'Nayarit'),
(19, 1, 'Nuevo Le�n'),
(20, 1, 'Oaxaca de Ju�rez'),
(21, 1, 'Puebla'),
(22, 1, 'Quer�taro'),
(23, 1, 'Quintana Roo'),
(24, 1, 'San Luis Potos�'),
(25, 1, 'Sinaloa'),
(26, 1, 'Sonora'),
(27, 1, 'Tabasco'),
(28, 1, 'Tamaulipas'),
(29, 1, 'Tlaxcala'),
(30, 1, 'Veracruz de Ignacio de la Llave'),
(31, 1, 'Yucat�n'),
(32, 1, 'Zacatecas');
GO
/*	Query #7
	Descripci�n: Creaci�n de Tablas [Ciudad].
	Cat�logo de Ciudades.*/
CREATE TABLE Ciudad(
	CiuPais NUMERIC(3,0) NOT NULL,
	CiuEstado NUMERIC(2,0) NOT NULL,
	CiuId NUMERIC(3,0) NOT NULL,
	CiuNombre VARCHAR(100) NOT NULL,
	PRIMARY KEY(CiuId),
	CONSTRAINT FK_Ciudad_Pais FOREIGN KEY(CiuPais) REFERENCES Pais(PaiId),
	CONSTRAINT FK_Ciudad_Estado FOREIGN KEY(CiuEstado) REFERENCES Estado(EstId));
GO
/*	Query #8
	Descripci�n: Insert en Tablas [Ciudad].
	Popular cat�logo de Ciudades.*/
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(1,1,1,'Aguascalientes');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(2,1,1,'Asientos');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(3,1,1,'Calvillo');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(4,1,1,'Cos�o');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(5,1,1,'Jes�s Mar�a');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(6,1,1,'Pabell�n de Arteaga');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(7,1,1,'Rinc�n de Romos');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(8,1,1,'San Jos� de Gracia');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(9,1,1,'Tepezal�');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(10,1,1,'Palo Alto');
	INSERT INTO Ciudad(CiuId, CiuPais, CiuEstado, CiuNombre)VALUES(11,1,1,'San Francisco de los Romo');
GO

/*	Query #9
	Descripci�n: Creaci�n de Tablas [Cliente].
	Guardar� la informaci�n de los Clientes que se registren en la aplicaci�n. */
CREATE TABLE Cliente(
	CliId INT IDENTITY(1,1) NOT NULL,
	CliNombre VARCHAR(25) NOT NULL,
	CliApellidoPaterno VARCHAR(25) NOT NULL,
	CliApellidoMaterno VARCHAR(25),
	CliFechaNacimiento DATE,
	CliCorreoElectronico VARCHAR(50) NOT NULL UNIQUE,
	CliContrasena VARCHAR(100) NOT NULL,
	CliNumeroTelefonico VARCHAR(10) NULL,
	CliNumeroCelular VARCHAR(10) NOT NULL,
	CliBloqueado BIT NOT NULL DEFAULT 0,
	CliFechaUltimoAcceso DATETIME NULL,
	CliFechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
	CliFechaUltimaActualizacion DATETIME NULL,
	CliFechaBaja DATETIME NULL,
	PRIMARY KEY(CliId) 
);


/*	Query #10
	Descripci�n: Creaci�n de Tablas [TipoMascota].
	Cat�logo del Tipo de Mascota que puede ser el animal.*/
CREATE TABLE TipoMascota(
	TmaId TINYINT NOT NULL,
	TmaNombre VARCHAR(50) NOT NULL,
	PRIMARY KEY(TmaId));

/*	Query #11
	Descripci�n: Insert en Tablas [TipoMascota].
	Popular el cat�logo de Tipos de Mascotas.*/
INSERT INTO TipoMascota(TmaId, TmaNombre) VALUES(1,'Perros');
INSERT INTO TipoMascota(TmaId, TmaNombre) VALUES(2,'Gatos');
INSERT INTO TipoMascota(TmaId, TmaNombre) VALUES(3,'Peces');
INSERT INTO TipoMascota(TmaId, TmaNombre) VALUES(99,'Otros');
GO

/*	Query #12
	Descripci�n: Creaci�n de Tablas [CategoriaMascota].
	Cat�logo de la categor�a a la que pertenece la mascota.*/
CREATE TABLE CategoriaMascota(
	CmaId TINYINT NOT NULL,
	CmaNombre VARCHAR(15),
	PRIMARY KEY(CmaId)
);

/*	Query #13
	Descripci�n: Insert en Tablas [CategoriaMascota].
	Popular el cat�logo de Categor�as de Mascota.*/
INSERT INTO CategoriaMascota(CmaId, CmaNombre) VALUES(1,'Tiny')
INSERT INTO CategoriaMascota(CmaId, CmaNombre) VALUES(2,'Peque�o')
INSERT INTO CategoriaMascota(CmaId, CmaNombre) VALUES(3,'Mediano')
INSERT INTO CategoriaMascota(CmaId, CmaNombre) VALUES(4,'Grande')
INSERT INTO CategoriaMascota(CmaId, CmaNombre) VALUES(5,'Gigante')

/*	Query #14
	Descripci�n: Creaci�n de Tablas [Mascota].
	Cat�logo de las mascotas registradas por los clientes.*/
CREATE TABLE Mascota(
	MasCliente INT NOT NULL,
	MasId TINYINT NOT NULL,
	MasNombre VARCHAR(50) NOT NULL,
	MasEdad TINYINT NOT NULL,
	MasTipoMascota TINYINT NOT NULL,
	MasTipoMascotaOtro VARCHAR(25) NULL,
	MasCategoriaMascota TINYINT NOT NULL,
	MasImagen VARCHAR(MAX) NOT NULL,
	MasCartillaPdf VARCHAR(MAX) NOT NULL,
	MasFechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY(MasCliente, MasId),
	CONSTRAINT FK_Mascota_Cliente FOREIGN KEY(MasCliente) REFERENCES Cliente(CliId),
	CONSTRAINT FK_Mascota_Tipo FOREIGN KEY(MasTipoMascota) REFERENCES TipoMascota(TmaId),
	CONSTRAINT FK_Mascota_Categoria FOREIGN KEY(MasCategoriaMascota) REFERENCES CategoriaMascota(CmaId)
);
GO

/*	Query #15
	Descripci�n: Creaci�n de Tablas [Hogar].
	Guardar� la informaci�n de los hogares registrados por los clientes al decidir ser anfitriones.*/
CREATE TABLE Hogar(
	HogId INT NOT NULL IDENTITY(1,1),
	HogCliente INT NOT NULL,
	HogDescripcion VARCHAR(500) NOT NULL,
	HogCostoPorNoche NUMERIC(12,2) NOT NULL,
	HogCapacidad TINYINT NOT NULL,
	HogCuentaConMascotas BIT NOT NULL,
	HogPublicado BIT NOT NULL DEFAULT 0,
	HogDisponible BIT NOT NULL DEFAULT 0,
	HogPausado BIT NOT NULL DEFAULT 0,
	HogFechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
	HogFechaUltimaActualizacion DATETIME NULL,
	PRIMARY KEY(HogId),
	CONSTRAINT FK_Hogar_Cliente FOREIGN KEY(HogCliente) REFERENCES Cliente(CliId)
)

/*	Query #16
	Descripci�n: Creaci�n de Tablas [HogarMultimedia].
	Guardar� la informaci�n multimedia (im�genes y video) del Hogar registrado.*/
CREATE TABLE HogarMultimedia(
	HmuHogar INT NOT NULL,
	HmuId TINYINT NOT NULL,
	HmuNombre VARCHAR(100) NOT NULL,
	HmuTipo TINYINT NOT NULL,
	HmuExtension VARCHAR(5) NOT NULL,
	PRIMARY KEY(HmuHogar, HmuId),
	CONSTRAINT FK_Hogar_Multimedia FOREIGN KEY(HmuHogar) REFERENCES Hogar(HogId)
);

/*	Query #17
	Descripci�n: Creaci�n de Tablas [HogarTipoMascota].
	Guardar� informaci�n adicional del tipo de mascota que aceptan en ese hogar. Puede tener m�s de un tipo de mascota relacionado.*/
CREATE TABLE HogarTipoMascota(
	HmaHogar INT NOT NULL,
	HmaTipoMascota TINYINT NOT NULL,
	PRIMARY KEY(HmaHogar),
	CONSTRAINT FK_HogarTipoMascota_TipoMascota FOREIGN KEY(HmaTipoMascota) REFERENCES TipoMascota(TmaId)
);
GO

/*	Query #18
	Descripci�n: Creaci�n de Tablas [EstatusReservacion].
	Cat�logo de los estatus posibles en una reservaci�n de acuerdo al momento en el que se encuentre.*/
CREATE TABLE EstatusReservacion(
	EreId TINYINT NOT NULL,
	EreNombre VARCHAR(15) NOT NULL,
	PRIMARY KEY(EreId)
);

/*	Query #19
	Descripci�n: Insert en Tablas [EstatusReservacion].
	Popular el cat�logo de los estatus o momentos de una reservaci�n.*/
INSERT INTO EstatusReservacion(EreId, EreNombre) VALUES(1, 'Pendiente')
INSERT INTO EstatusReservacion(EreId, EreNombre) VALUES(2, 'Aceptada')
INSERT INTO EstatusReservacion(EreId, EreNombre) VALUES(3, 'En Proceso')
INSERT INTO EstatusReservacion(EreId, EreNombre) VALUES(4, 'Terminada')
INSERT INTO EstatusReservacion(EreId, EreNombre) VALUES(99, 'Cancelada')

/*	Query #20
	Descripci�n: Creaci�n de Tablas [Reservacion].
	Guardar� la informaci�n de la reservaci�n del cliente, qu� mascota tendr� el servicio y en qu� hogar se prestar� este servicio.*/
CREATE TABLE Reservacion(
	ResId CHAR(9) NOT NULL,
	ResCliente INT NOT NULL,
	ResHogar INT NOT NULL,
	ResMascota TINYINT NOT NULL,
	ResEstatus TINYINT NOT NULL,
	ResFechaEntrada DATETIME NOT NULL,
	ResFechaSalida DATETIME NOT NULL,
	ResMontoTotal NUMERIC(12,2) NOT NULL,
	ResRecibeAlimento BIT,
	ResDescripcionAlimento VARCHAR(500),
	ResComentariosCliente VARCHAR(500),
	ResFechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY(ResId),
	CONSTRAINT FK_Reservacion_Cliente FOREIGN KEY(ResCliente) REFERENCES Cliente(CliId),
	CONSTRAINT FK_Reservacion_Hogar FOREIGN KEY(ResHogar) REFERENCES Hogar(HogId),
	CONSTRAINT FK_Reservacion_Estatus FOREIGN KEY(ResEstatus) REFERENCES EstatusReservacion(EreId)
);

/*	Query #21
	Descripci�n: Creaci�n de Tablas [EtapaReservacion].
	Cat�logo de las Etapas de la reservaci�n para registrar un historial de cada paso de la reservaci�n.*/
CREATE TABLE EtapaReservacion(
	EtrId TINYINT NOT NULL,
	EtrNombre VARCHAR(50) NOT NULL,
	PRIMARY KEY(EtrId)
);

/*	Query #22
	Descripci�n: Insert en Tablas [EtapaReservacion].
	Popular el cat�logo de las etapas por las que debe pasar una reservaci�n.*/
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(1, 'Pendiente por Aceptar');
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(2, 'En Espera de Entrada');
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(3, 'Inicio de Estancia');
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(4, 'Fin de Estancia');
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(5, 'Servicio Completado');
INSERT INTO EtapaReservacion(EtrId, EtrNombre) VALUES(99, 'Servicio Cancelado');

/*	Query #23
	Descripci�n: Creaci�n de Tablas [HistorialReservacion].
	Guardar� informaci�n sobre el historial  de vida de la reservaci�n, anexando un comentario en caso de necesitarse.*/
CREATE TABLE HistorialReservacion(
	HreReservacion CHAR(9) NOT NULL,
	HreId TINYINT NOT NULL,
	HreEtapa TINYINT NOT NULL,
	HreFecha DATETIME DEFAULT GETDATE(),
	HreComentarios VARCHAR(500) NULL,
	PRIMARY KEY(HreReservacion, HreId),
	CONSTRAINT FK_Historial_Reservacion FOREIGN KEY(HreReservacion) REFERENCES Reservacion(ResId)
);

/*
	--NONE AT THE MOMENT--
	Descripci�n: Actualizaci�n de Tablas [NombreTabla].
	
	Actualizaci�n yyyy-MM-dd:
	Motivo de la actualizaci�n. Diferencias entre la versi�n anterior y versi�n nueva.
*/


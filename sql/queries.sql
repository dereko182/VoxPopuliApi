ALTER TABLE Campania ADD FOREIGN KEY (TipoCampaniaId) REFERENCES TipoCampania(TipoCampaniaId);
ALTER TABLE CampaniaDetalle ADD FOREIGN KEY (CampaniaId) REFERENCES Campania(CampaniaId);
ALTER TABLE CampaniaDetalle ADD FOREIGN KEY (PreguntaId) REFERENCES Pregunta(PreguntaId);

ALTER TABLE ControlPregunta ADD FOREIGN KEY (PreguntaId) REFERENCES Pregunta(PreguntaId);
ALTER TABLE ControlPregunta ADD FOREIGN KEY (RespuestaId) REFERENCES Respuesta(RespuestaId);

ALTER TABLE ControlVotacion ADD FOREIGN KEY (CampaniaId) REFERENCES Campania(CampaniaId);

ALTER TABLE Pregunta ADD FOREIGN KEY (TipoControlId) REFERENCES TipoControl(TipoControlId);

ALTER TABLE RespuestaCampania ADD FOREIGN KEY (CampaniaDetalleId, campaniaId) REFERENCES CampaniaDetalle(CampaniaDetalleId,campaniaId);


ALTER TABLE RespuestaCampania ADD FOREIGN KEY (RespuestaId) REFERENCES Respuesta(RespuestaId)


CREATE TABLE Campania
(	
	CampaniaId int identity (1,1),
	Nombre text not null default '',
	Descripcion text not null default '',
	Estatus tinyint not null default 0,
	TipoCampaniaId int not null default 0,
	FechaInicia datetime not null default current_timestamp,
	FechaFinaliza datetime not null default current_timestamp
 CONSTRAINT [PK_Campania] PRIMARY KEY CLUSTERED 
(
	CampaniaID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


CREATE TABLE CampaniaDetalle
(	
	CampaniaDetalleId int identity (1,1),
	CampaniaId int not null,	
	PreguntaId int not null,
	Orden int not null default 0,
	Fecha datetime not null default current_timestamp,	
 CONSTRAINT [PK_CampaniaDetalle] PRIMARY KEY CLUSTERED 
(
	CampaniaDetalleId ASC,
	CampaniaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE Pregunta
(	
	PreguntaId int identity (1,1),	
	Nombre text not null default '',	
	TipoControlId int not null default 0
	Fecha datetime not null default current_timestamp,	
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
 
(
	PreguntaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE Respuesta
(	
	RespuestaId int identity (1,1),	
	Respuesta text not null default '',
	Descripcion text not null default '',
	Fecha datetime not null default current_timestamp,	
 CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED 
(
	RespuestaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE ControlPregunta
(	
	PreguntaId int not null,	
	RespuestaId int not null default 0,	
	Orden int not null default 0,
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_ControlPregunta] PRIMARY KEY CLUSTERED 
(
	PreguntaId ASC,
	RespuestaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE RespuestaCampania
(	
	CampaniaDetalleId int not null default 0,
	CampaniaId int not null default 0,	
	RespuestaId int not null,
	OpcionRespuesta tinyint not null default 0,
	ContadorRespuesta int not null default 0,
	Comentarios text not null default '',
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_RespuestaCampania] PRIMARY KEY CLUSTERED 
(
	CampaniaDetalleId ASC,	
	CampaniaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE ControlVotacion
(		
	CampaniaId int not null,	
	DeviceId varchar(50) not null default '',
	Latitud text not null default '',
	Longitud text not null default '',
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_ControlVotacion] PRIMARY KEY CLUSTERED 
(
	CampaniaId ASC,
	DeviceId ASC	
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];


CREATE TABLE TipoCampania
(		
	TipoCampaniaId int identity(1,1),	
	Nombre text not null default '',
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_TipoCampania] PRIMARY KEY CLUSTERED 
(
	TipoCampaniaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE TipoControl
(		
	TipoControlId int identity(1,1),	
	Nombre text not null default '',
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_TipoControl] PRIMARY KEY CLUSTERED 
(
	TipoControlId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];


CREATE TABLE TipoPregunta
(		
	TipoPreguntaId int identity(1,1),	
	Nombre text not null default '',
	Fecha datetime not null default current_timestamp
 CONSTRAINT [PK_TipoPregunta] PRIMARY KEY CLUSTERED 
(
	TipoPreguntaId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];





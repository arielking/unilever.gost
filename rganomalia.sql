﻿CREATE TABLE [dbo].[tb_registro_anomalia] (
    [idrgsanomalia]               INT             IDENTITY (1, 1) NOT NULL,
    [codigo]           AS              ('N° '+right('000000'+CONVERT([varchar],[idrgsanomalia]),(6))),
    [emision_ts]       DATETIME        NOT NULL,
    [idusuario]        INT             NOT NULL,
    [paso_ma]          INT             NULL,
    [criticidad]       NVARCHAR (1)    NULL,
    [turno]            VARCHAR (2)     NULL,

    [idarea]           INT             NOT NULL,
    [idequipo]         INT             NOT NULL,
    [idanomalia]       INT             NULL,
    [idsucesorelac]    INT             NOT NULL,
    [idtarjeta]        INT             NOT NULL,
    [descripcion]      NVARCHAR (200)  NULL,
    [sol_implementada] NVARCHAR (250)  NULL,
    [ejecucion_ts]     DATETIME        NULL,
    [cierre_ts]        DATETIME        NULL,
    [idresuelto]       INT             NULL,
    [confirmacion1]     BIT             NULL,
    [idsupervisor]     INT             NULL,
	[confirmacion2]     BIT             NULL,
    [obervaciones]     NVARCHAR (200)  NULL,
    [prog]             BIT             NULL,
    [foto]             VARBINARY (MAX) NULL,
    [eliminado]        BIT             NULL,
    PRIMARY KEY CLUSTERED ([idrgsanomalia] ASC),
    FOREIGN KEY ([idusuario]) REFERENCES [dbo].[usuario] ([idusuario]),
    FOREIGN KEY ([idarea]) REFERENCES [dbo].[tb_area] ([idarea]),
    FOREIGN KEY ([idequipo]) REFERENCES [dbo].[tb_equipo] ([idequipo]),
    FOREIGN KEY ([idanomalia]) REFERENCES [dbo].[tb_anomalia] ([idanomalia]),
    FOREIGN KEY ([idsucesorelac]) REFERENCES [dbo].[tb_suceso_relacionado] ([idsucesorelac]),
    FOREIGN KEY ([idtarjeta]) REFERENCES [dbo].[tb_tarjeta] ([idtarjeta]),
    FOREIGN KEY ([idresuelto]) REFERENCES [dbo].[usuario] ([idusuario]),
    FOREIGN KEY ([idsupervisor]) REFERENCES [dbo].[usuario] ([idusuario])
);
CREATE TABLE [dbo].[tb_maquina] (
    [idmaquina]        INT          IDENTITY (1, 1) NOT NULL,
	[idarea]   INT          NULL,
    [nombre]    VARCHAR (50) NULL,
	[activo] BIT NULL,
    [eliminado] BIT          NULL,
    PRIMARY KEY CLUSTERED ([idmaquina] ASC),
    FOREIGN KEY (idarea) REFERENCES [dbo].[tb_area] ([idmaquina])
);


CREATE TABLE [dbo].[tb_tipo_falla] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      NVARCHAR (50) NULL,
    [descripcion] NVARCHAR (50) NULL,
    [activo]      BIT           NULL,
    [eliminado]   BIT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

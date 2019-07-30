CREATE TABLE [dbo].[tb_suceso_relacionado] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre]      NVARCHAR (100) NOT NULL,
    [descripcion] NVARCHAR (150) NULL,
    [activo]      BIT            NULL,
    [eliminado]   BIT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
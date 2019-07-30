CREATE TABLE [dbo].[tb_cond_inseg] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      NVARCHAR (50) NULL,
    [descripcion] NVARCHAR (50) NULL,
    [activo]      BIT           NULL,
    [eliminado]   BIT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

﻿CREATE TABLE [dbo].[Produit]
(
	[Id] INT NOT NULL IDENTITY, 
	[Nom] NVARCHAR(50) NOT NULL,
    [Prix] FLOAT NOT NULL,
    CONSTRAINT [PK_Produit] PRIMARY KEY ([Id])
)

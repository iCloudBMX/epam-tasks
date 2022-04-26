﻿CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Street] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(20) NOT NULL,
	[State] NVARCHAR(50) NOT NULL,
	[ZipCode] NVARCHAR(50) NOT NULL
)

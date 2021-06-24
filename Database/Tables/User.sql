﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastName] NVARCHAR(75) NOT NULL, 
    [FirstName] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(384) UNIQUE NOT NULL, 
    [Password] BINARY(64) NOT NULL, 
    [IsAdmin] BIT NOT NULL DEFAULT 0
)

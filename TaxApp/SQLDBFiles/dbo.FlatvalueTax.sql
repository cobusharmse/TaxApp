﻿CREATE TABLE [dbo].[FlatValueTax]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Rate] DECIMAL(5, 2) NOT NULL, 
    [Value] DECIMAL(16, 2) NOT NULL, 
    [MinValue] DECIMAL(16, 2) NOT NULL
)

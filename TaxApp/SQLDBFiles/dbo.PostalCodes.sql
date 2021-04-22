CREATE TABLE [dbo].[PostalCodes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PostalCodeDescription] VARCHAR(50) NOT NULL, 
    [PostalCodeValue] VARCHAR(50) NOT NULL
)

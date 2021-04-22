CREATE TABLE [dbo].[History]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateTime] DATETIME NULL DEFAULT getdate(), 
    [Salary] DECIMAL(16, 2) NOT NULL, 
    [TaxAmount] DECIMAL(16, 2) NOT NULL, 
    [TaxType] VARCHAR(50) NOT NULL
)

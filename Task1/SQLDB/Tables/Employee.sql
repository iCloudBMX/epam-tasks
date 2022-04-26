CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[AddressId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Address](Id),
	[PersonId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Person](Id),
	[CompanyName] NVARCHAR(20) NOT NULL,
	[Position] NVARCHAR(30) NOT NULL,
	[EmployeeName] NVARCHAR(100) NULL	
)
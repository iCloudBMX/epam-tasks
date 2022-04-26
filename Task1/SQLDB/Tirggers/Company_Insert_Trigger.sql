CREATE TRIGGER [dbo].[Company_Insert_Trigger]
ON [dbo].[Employee]
AFTER INSERT
AS
	DECLARE @CompanyName NVARCHAR(100)
	DECLARE @AddressId INT
	
	SELECT @CompanyName = INSERTED.[CompanyName], @AddressId = INSERTED.[AddressId]
		FROM INSERTED
	
	INSERT INTO [dbo].[Company]
		([Name], [AddressId]) VALUES (@CompanyName, @AddressId)

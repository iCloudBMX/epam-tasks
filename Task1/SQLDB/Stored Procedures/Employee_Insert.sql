CREATE PROCEDURE [dbo].[Employee_Insert]
	@EmployeeName NVARCHAR(100) = NULL,
	@FirstName NVARCHAR(50) = NULL,
	@LastName NVARCHAR(50) = NULL,
	@CompanyName NVARCHAR(20),
	@Position NVARCHAR(30) = NULL,
	@Street NVARCHAR(50),
	@City NVARCHAR(20) = NULL,
	@State NVARCHAR(50) = NULL,
	@ZipCode NVARCHAR(50) = NULL
AS
	DECLARE @PersonID AS INT;
	DECLARE @AddressID AS INT
	
	INSERT INTO [dbo].[Person] (FirstName, LastName)
		VALUES (@FirstName, @LastName)

	SET @PersonID = SCOPE_IDENTITY();
	
	INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode])
		VALUES (@Street, @City, @State, @ZipCode)

	SET @AddressID = SCOPE_IDENTITY()
	
	INSERT INTO [dbo].[Employee] (EmployeeName, CompanyName, PersonId, AddressId, Position)
	
		VALUES (@EmployeeName, @CompanyName, @PersonID, @AddressID, @Position)	
	
RETURN 0

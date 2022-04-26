CREATE VIEW [dbo].[EmployeeInfo]
AS 
	SELECT TOP(100) PERCENT
		[Employee].[Id] AS EmployeeId, 
		CASE
			WHEN [Employee].[EmployeeName] IS NULL THEN ([Person].[FirstName] + ' ' + [Person].[LastName])
			ELSE [Employee].[EmployeeName]
		 END AS EmployeeFullName,  
		([Address].[ZipCode] + '_' + [Address].[State] + ',' + [Address].[City] + '-' + [Address].[Street]) as EmployeeFullAddress,
		([Employee].[CompanyName] + '(' + [Employee].[Position] + ')') as EmployeeCompanyFullInfo
		
		FROM [Employee] 
			JOIN [Person] ON [Person].[Id] = [Employee].[PersonId]
			JOIN [Address] ON [Address].[Id] = [Employee].[AddressId]
		
		ORDER BY [Employee].[CompanyName];

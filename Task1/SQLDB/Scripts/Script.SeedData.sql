/* Person Seed Data */

insert into [dbo].[Person] (
	[Id],
	[FirstName],
	[LastName]) 
values 
	(1, 'Xondamir', 'Abduxoshimov'),
	(2, 'Nozimjon', 'Kozimov');
	

/* Address Seed Data */

insert into [dbo].[Address] (
	[Id],
	[Street],
	[City],
	[State],
	[ZipCode])
values 
	(1, 'Beruniy', 'Mirzo Ulugbek', 'Tashkent', '10001'),
	(2, 'Saylgoh', 'Yunusobod', 'Tashkent', '10002');
	

/* Employee Seed Data */

insert into [dbo].[Employee] (
	[Id],
	[PersonId],
	[AddressId],
	[CompanyName],
	[Position],
	[EmployeeName])
values	
	(1, 1, 1, 'Epam', 'Software Engineer', 'Khan'),
	(2, 2, 2, 'Data Site', 'Frontend Developer', NULL);
				
/* Company Seed Data */

insert into [dbo].[Company] (
	[Id],
	[Name],
	[AddressId]) 
values	
	(1, 'Epam', 1),
	(2, 'Data Site', 2);
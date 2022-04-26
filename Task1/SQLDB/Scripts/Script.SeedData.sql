/* Person Seed Data */

insert into [dbo].[Person] (
	[FirstName],
	[LastName]) 
values 
	('Xondamir', 'Abduxoshimov'),
	('Nozimjon', 'Kozimov');
	

/* Address Seed Data */

insert into [dbo].[Address] (
	[Street],
	[City],
	[State],
	[ZipCode])
values 
	('Beruniy', 'Mirzo Ulugbek', 'Tashkent', '10001'),
	('Saylgoh', 'Yunusobod', 'Tashkent', '10002');
	

/* Employee Seed Data */

insert into [dbo].[Employee] (
	[PersonId],
	[AddressId],
	[CompanyName],
	[Position],
	[EmployeeName])
values	
	(1, 1, 'Epam', 'Software Engineer', 'Khan'),
	(2, 2, 'Data Site', 'Frontend Developer', NULL);
				
/* Company Seed Data */

insert into [dbo].[Company] (
	[Name],
	[AddressId]) 
values	
	('Epam', 1),
	('Data Site', 2);
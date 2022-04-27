USE TempDb;

CREATE PROCEDURE [dbo].[Order]
	@Date datetime = NULL,
	@Status int = NULL,
	@ProductId varchar(30)
AS		
	select * from [dbo].[Order] 
		where [Date] LIKE @Date or [Status] LIKE @Status or [ProductId] LIKE @ProductId;
	
RETURN 0;
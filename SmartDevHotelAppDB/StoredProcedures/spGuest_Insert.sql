CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spGuest_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)

AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (
		SELECT 
			1 
		FROM 
			SMARTDEV_HOTEL_APP.Guest AS G
		WHERE 
			G.FirstName = @FirstName 
			AND G.LastName = @LastName)
	BEGIN
		INSERT INTO SMARTDEV_HOTEL_APP.Guest(
			FirstName, 
			LastName)
		VALUES(
			@firstName, 
			@lastName);
	END

	SELECT TOP 1 
		G.Id, 
		G.FirstName, 
		G.LastName
	FROM 
		SMARTDEV_HOTEL_APP.Guest AS G
	WHERE 
		G.FirstName = @FirstName 
		AND G.LastName = @LastName;

END
GO


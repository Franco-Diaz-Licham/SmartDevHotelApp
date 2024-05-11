CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spBooking_Search]
	@LastName nvarchar(50),
	@StartDate date,
	@CheckedIn bit

AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		B.Id, 
		B.RoomId, 
		B.GuestId, 
		B.StartDate, 
		B.EndDate, 
		B.CheckedIn, 
		B.TotalCost, 
		G.FirstName, 
		G.LastName, 
		R.RoomNumber, 
		R.RoomTypeId, 
		RT.Title, 
		RT.Description, 
		RT.Price
	FROM 
		SMARTDEV_HOTEL_APP.Booking AS B
		INNER JOIN SMARTDEV_HOTEL_APP.Guest AS G 
			ON B.GuestId = G.Id
		INNER JOIN SMARTDEV_HOTEL_APP.Room AS R 
			ON B.RoomId = R.Id
		INNER JOIN SMARTDEV_HOTEL_APP.RoomType AS RT 
			ON R.RoomTypeId = RT.Id
	WHERE 
		B.StartDate = @StartDate 
		AND G.LastName = @LastName
		AND B.CheckedIn = @CheckedIn;
END
GO

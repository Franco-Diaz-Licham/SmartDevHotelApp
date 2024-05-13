CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoom_GetAvailableRooms]
	@StartDate date,
	@EndDate date,
	@RoomTypeId int

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		R.*
	FROM 
		SMARTDEV_HOTEL_APP.Room AS R
		INNER JOIN SMARTDEV_HOTEL_APP.RoomType AS T 
			ON T.Id = R.RoomTypeId
	WHERE 
		R.RoomTypeId = @RoomTypeId
		AND R.Id NOT IN(
			SELECT 
				B.RoomId
			FROM 
				SMARTDEV_HOTEL_APP.Booking AS B
			WHERE 
				(@StartDate < b.StartDate AND @EndDate > b.EndDate)
				OR (b.StartDate <= @EndDate AND @EndDate < b.EndDate)
				OR (b.StartDate <= @StartDate AND @StartDate < b.EndDate)
	);

END
GO

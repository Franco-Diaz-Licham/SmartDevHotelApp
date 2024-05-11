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
				(@startDate < b.StartDate AND @endDate > b.EndDate)
				OR (b.StartDate <= @endDate AND @endDate < b.EndDate)
				OR (b.StartDate <= @startDate AND @startDate < b.EndDate)
	);

END
GO

CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoomType_GetAvailableTypes]
	@StartDate date,
	@EndDate date
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		T.Id, 
		T.Title, 
		T.Description, 
		T.Price
	FROM 
		SMARTDEV_HOTEL_APP.Room AS R
		INNER JOIN SMARTDEV_HOTEL_APP.RoomType AS T
			ON T.Id = R.RoomTypeId
	WHERE 
		R.Id NOT IN (
			SELECT 
				B.RoomId
			FROM 
				SMARTDEV_HOTEL_APP.Booking AS B
			WHERE 
				(@StartDate < B.StartDate AND @EndDate > B.EndDate)
				OR (B.StartDate <= @EndDate AND @EndDate < B.EndDate)
				OR (B.StartDate <= @StartDate AND @StartDate < B.EndDate))
	GROUP BY
		T.Id, 
		T.Title, 
		T.Description, 
		T.Price
END
GO


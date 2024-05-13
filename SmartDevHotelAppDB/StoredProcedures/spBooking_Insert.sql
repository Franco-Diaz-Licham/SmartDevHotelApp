CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spBooking_Insert]
	@RoomId int,
	@GuestId int,
	@StartDate date,
	@EndDate date,
	@TotalCost money
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO SMARTDEV_HOTEL_APP.Booking(
		RoomId, 
		GuestId, 
		StartDate, 
		EndDate, 
		TotalCost)
	VALUES(
		@RoomId, 
		@GuestId,
		@StartDate, 
		@EndDate, 
		@TotalCost);
END

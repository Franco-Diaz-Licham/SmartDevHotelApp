CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spBooking_Insert]
	@RoomId int,
	@GuestId int,
	@StartDate date,
	@EndDate date,
	@TotalCost money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO SMARTDEV_HOTEL_APP.Booking(
		RoomId, 
		GuestId, 
		StartDate, 
		EndDate, 
		TotalCost)
	values(
		@RoomId, 
		@GuestId,
		@StartDate, 
		@EndDate, 
		@TotalCost);
END

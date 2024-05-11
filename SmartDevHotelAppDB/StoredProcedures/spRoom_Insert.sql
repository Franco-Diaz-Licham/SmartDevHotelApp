CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoom_Insert]
	@RoomNumber int,
	@RoomTypeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO SMARTDEV_HOTEL_APP.Room(
		RoomNumber,
		RoomTypeId)
	VALUES(
		@RoomNumber,
		@RoomTypeId)
END
GO



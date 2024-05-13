CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoom_Insert]
	@RoomNumber int,
	@RoomTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO SMARTDEV_HOTEL_APP.Room(
		RoomNumber,
		RoomTypeId)
	VALUES(
		@RoomNumber,
		@RoomTypeId)
END
GO



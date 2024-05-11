
CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoomType_Insert]
	@Title nvarchar(50),
	@Description nvarchar(50),
	@Price money

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO SMARTDEV_HOTEL_APP.RoomType(
		Title,
		Description,
		Price)
	VALUES(
		@Title,
		@Description,
		@Price)
END
GO



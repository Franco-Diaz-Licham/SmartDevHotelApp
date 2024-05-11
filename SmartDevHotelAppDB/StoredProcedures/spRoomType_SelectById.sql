CREATE PROCEDURE [SMARTDEV_HOTEL_APP].[spRoomType_SelectById]
	@RoomTypeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		* 
	FROM 
		SMARTDEV_HOTEL_APP.RoomType AS RT
	WHERE 
		RT.Id = @RoomTypeId
END
GO



namespace SmartDevHotelAppLibrary.Helpers;

public static class SqliteDataProcessor
{
    public static void SqliteParseRoomType(
        this RoomTypeModel model)
    {
        model.Price = model.Price / 100;
    }
}

namespace SmartDevHotelAppLibrary.Helpers;

public static class SqliteDataProcessor
{
    public static void SqliteParseRoomType(
        this RoomTypeModel model)
    {
        model.Price = model.Price / 100;
    }

    public static void SqliteBookingFull(
            this BookingFullModel model)
    {
        model.Price = model.Price / 100;
        model.TotalCost = model.TotalCost / 100;
    }
}

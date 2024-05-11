namespace SmartDevHotelAppLibrary.Data;

public class SqlData : IDatabaseData
{
    private readonly ISqlDataAccess Db;
    private const string cnx = "SqlDb";

    public SqlData(ISqlDataAccess db)
    {
        Db = db;
    }

    public List<RoomTypeModel> GetAvailableRoomTypes(
            DateTime start,
            DateTime end)
    {
        string sp = "SMARTDEV_HOTEL_APP.spRoomType_GetAvailableTypes";
        object p = new { StartDate = start, EndDate = end };
        var result = Db.LoadData<RoomTypeModel, dynamic>(sp, p, cnx, true);

        return result;
    }

    public void BookGuest(
            string firstName,
            string lastName,
            DateTime startDate,
            DateTime endDate,
            int roomTypeId)
    {
        string spGuest = "SMARTDEV_HOTEL_APP.spGuest_Insert";
        string spRoomType = "SMARTDEV_HOTEL_APP.spRoomType_SelectById";
        string spAvailableRooms = "SMARTDEV_HOTEL_APP.spRoom_GetAvailableRooms";
        string spBookings = "SMARTDEV_HOTEL_APP.spBooking_Insert";

        object pGuest = new { Firstname = firstName, LastName = lastName };
        object pRoomType = new { RoomTypeId = roomTypeId };
        object pAvailableRooms = new { StartDate = startDate, EndDate = endDate, RoomTypeId = roomTypeId };
        TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

        GuestModel guest = Db.LoadData<GuestModel, dynamic>(spGuest, pGuest, cnx, true).First();
        RoomTypeModel roomType = Db.LoadData<RoomTypeModel, dynamic>(spRoomType, pRoomType, cnx, true).First();
        List<RoomModel> avialableRooms = Db.LoadData<RoomModel, dynamic>(spAvailableRooms, pAvailableRooms, cnx, true);

        object pBooking = new
        {
            RoomId = avialableRooms.First().Id,
            GuestId = guest.Id,
            StartDate = startDate,
            EndDate = endDate,
            TotalCost = timeStaying.Days * roomType.Price
        };

        Db.SaveData(spBookings, pBooking, cnx, true);
    }

    public List<BookingFullModel> SearchBookings(
            string lastName,
            DateTime startDate,
            bool checkedIn)
    {
        string sp = "SMARTDEV_HOTEL_APP.spBooking_Search";
        object p = new { LastName = lastName, StartDate = startDate, CheckedIn = checkedIn };
        var result = Db.LoadData<BookingFullModel, dynamic>(sp, p, cnx, true);

        return result;
    }

    public void CheckInGuest(
            int bookingId)
    {
        string sp = "SMARTDEV_HOTEL_APP.spBooking_CheckIn";
        object p = new { Id = bookingId };

        Db.SaveData(sp, p, cnx, true);
    }

    public void CreateRoomTypes(
            RoomTypeModel model)
    {
        string sp = "SMARTDEV_HOTEL_APP.spRoomType_Insert";
        object p = new 
        { 
            model.Title,
            model.Description,
            model.Price,
        };

        Db.SaveData(sp, p, cnx, true);
    }

    public void CreateRooms(
            RoomModel model)
    {
        string sp = "SMARTDEV_HOTEL_APP.spRoom_Insert";
        object p = new
        {
            model.RoomNumber,
            model.RoomTypeId
        };

        Db.SaveData(sp, p, cnx, true);
    }
}

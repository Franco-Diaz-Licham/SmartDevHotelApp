namespace SmartDevHotelAppLibrary.DataAccess;

public class SqliteData : IDatabaseData
{
    private readonly ISqliteDataAccess Db;
    private const string cnx = "Sqlite";

    public SqliteData(
            ISqliteDataAccess db)
    {
        Db = db;
    }

    public void BookGuest(
            string firstName, 
            string lastName, 
            DateTime startDate, 
            DateTime endDate, 
            int roomTypeId)
    {
        SqliteQueries.Guest.TryGetValue("Insert", out var sqlGuest);
        SqliteQueries.RoomType.TryGetValue("SelectById", out var sqlRoomType);
        SqliteQueries.Room.TryGetValue("GetAvailableRooms", out var sqlAvailableRooms);
        SqliteQueries.Booking.TryGetValue("Insert", out var sqlBookings);

        object pGuest = new { Firstname = firstName, LastName = lastName };
        object pRoomType = new { RoomTypeId = roomTypeId };
        object pAvailableRooms = new { StartDate = startDate, EndDate = endDate, RoomTypeId = roomTypeId };
        TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

        GuestModel guest = Db.LoadData<GuestModel, dynamic>(sqlGuest!, pGuest, cnx).First();
        RoomTypeModel roomType = Db.LoadData<RoomTypeModel, dynamic>(sqlRoomType!, pRoomType, cnx).First();
        List<RoomModel> avialableRooms = Db.LoadData<RoomModel, dynamic>(sqlAvailableRooms!, pAvailableRooms, cnx);

        object pBooking = new
        {
            RoomId = avialableRooms.First().Id,
            GuestId = guest.Id,
            StartDate = startDate,
            EndDate = endDate,
            TotalCost = timeStaying.Days * roomType.Price
        };

        Db.SaveData(sqlBookings!, pBooking, cnx);
    }

    public void CheckInGuest(
            int bookingId)
    {
        SqliteQueries.Booking.TryGetValue("CheckIn", out var sp);
        object p = new { Id = bookingId };

        Db.SaveData(sp!, p, cnx);
    }

    public void CreateRooms(RoomModel model)
    {
        SqliteQueries.Room.TryGetValue("Insert", out var sp);
        object p = new
        {
            model.RoomNumber,
            model.RoomTypeId
        };

        Db.SaveData(sp!, p, cnx);
    }

    public void CreateRoomTypes(RoomTypeModel model)
    {
        throw new NotImplementedException();
    }

    public List<RoomTypeModel> GetAvailableRoomTypes(
            DateTime start, 
            DateTime end)
    {
        SqliteQueries.RoomType.TryGetValue("GetAvailableTypes", out var sp);
        object p = new { StartDate = start, EndDate = end };
        var result = Db.LoadData<RoomTypeModel, dynamic>(sp!, p, cnx);

        result.ForEach(m => m.SqliteParseRoomType());

        return result;
    }

    public List<BookingFullModel> SearchBookings(
            string lastName, 
            DateTime startDate, 
            bool checkedIn)
    {
        SqliteQueries.Booking.TryGetValue("Search", out var sp);
        object p = new { LastName = lastName, StartDate = startDate, CheckedIn = checkedIn };
        var result = Db.LoadData<BookingFullModel, dynamic>(sp!, p, cnx);

        return result;
    }
}

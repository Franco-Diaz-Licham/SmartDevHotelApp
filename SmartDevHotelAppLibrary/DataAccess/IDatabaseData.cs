
namespace SmartDevHotelAppLibrary.Data;

public interface IDatabaseData
{
    void BookGuest(
            string firstName, 
            string lastName, 
            DateTime startDate, 
            DateTime endDate, 
            int roomTypeId);
    void CheckInGuest(
            int bookingId);
    void CreateRooms(
            RoomModel model);
    void CreateRoomTypes(
            RoomTypeModel model);
    List<RoomTypeModel> GetAvailableRoomTypes(
            DateTime start, 
            DateTime end);
    List<BookingFullModel> SearchBookings(
            string lastName, 
            DateTime startDate,
            bool checkedIn);
}
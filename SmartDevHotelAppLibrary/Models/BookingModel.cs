namespace SmartDevHotelAppLibrary.Models;

public class BookingModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public RoomModel? Room { get; set; }
    public int GuestId { get; set; }
    public GuestModel? Guest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool CheckedIn { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedOn { get; set; }
}

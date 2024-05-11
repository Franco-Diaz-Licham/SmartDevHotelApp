namespace SmartDevHotelAppLibrary.Models;

public class RoomModel
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public int RoomTypeId { get; set; }
    public RoomTypeModel? RoomType { get; set; }
    public DateTime CreatedOn { get; set; }
}

namespace SmartDevHotelApp.Desktop;

public partial class BookingForm : Window
{
    private readonly IDatabaseData Db;
    private RoomTypeModel? RoomType {  get; set; }
    private DateTime? StarteDate { get; set; }
    private DateTime? EndDate { get; set; }

    public BookingForm(IDatabaseData db)
    {
        InitializeComponent();
        Db = db;
    }

    public void PopulateInformation(
            RoomTypeModel model,
            DateTime startDate,
            DateTime endDate)
    {
        RoomType = model;
        StarteDate = startDate;
        EndDate = endDate;
    }

    private void BookButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        if (StarteDate is null)
            return;
        if(EndDate is null) 
            return;
        if(RoomType is null)
            return;

        Db.BookGuest(firstNameText.Text, 
                    lastNameText.Text, 
                    StarteDate.Value, 
                    EndDate.Value, 
                    RoomType.Id);

        Close();
    }
}

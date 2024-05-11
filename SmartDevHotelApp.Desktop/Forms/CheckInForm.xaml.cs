namespace SmartDevHotelApp.Desktop;

public partial class CheckInForm : Window
{
    private readonly IDatabaseData Db;
    private BookingFullModel? data { get; set;}

    public CheckInForm(IDatabaseData db)
    {
        Db = db;
        InitializeComponent();
    }

    public void PopulateInformation(BookingFullModel Data)
    {
        data = Data;
        firstNameText.Text = data.FirstName;
        lastNameText.Text = data.LastName;
        titleText.Text = data.Title;
        roomNumberText.Text = data.RoomNumber;
        totalCostText.Text = string.Format("{0:C}", data.TotalCost);
    }

    private void CheckInUserButtonClick(object sender, RoutedEventArgs e)
    {
        Db.CheckInGuest(data.Id);
        Close();
    }
}

namespace SmartDevHotelApp.Desktop.Forms;

public partial class RoomSearchForm : Window
{
    public IDatabaseData Db { get; }

    public RoomSearchForm(IDatabaseData db)
    {
        InitializeComponent();
        Db = db;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        startDatePicker.SelectedDate = DateTime.Now;
        endDatePicker.SelectedDate = DateTime.Now;
    }

    public void PopulateInformation()
    {
        
    }

    private void SearchButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var startDate = startDatePicker.SelectedDate;
        var endDate = endDatePicker.SelectedDate;

        if(startDate is null)
            return;
        if(endDate is null)
            return;

        resultsList.ItemsSource = Db.GetAvailableRoomTypes(startDate.Value, endDate.Value);
    }

    private void BookRoomButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var bookingForm = App.Provider.GetService<BookingForm>();
        var model = (RoomTypeModel)((Button)e.Source).DataContext;

        if(model is null) 
            return;

        var start = startDatePicker.SelectedDate;
        var end = endDatePicker.SelectedDate;
        bookingForm.PopulateInformation(model, start.Value, end.Value);
        bookingForm.Show();
    }
}

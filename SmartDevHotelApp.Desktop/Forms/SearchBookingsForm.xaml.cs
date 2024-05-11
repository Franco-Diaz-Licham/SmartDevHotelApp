
namespace SmartDevHotelApp.Desktop.Forms;

public partial class SearchForBookingsForm : Window
{
    private readonly IDatabaseData Db;

    public SearchForBookingsForm(IDatabaseData db)
    {
        InitializeComponent();
        Db = db;
    }

    private void SearchForGuestButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var startDate = startDatePicker.SelectedDate;
        var checkIn = checkInCheckBox.IsChecked;

        if (startDate is null)
            return;
        if(checkIn is null)
            checkIn = false;

        resultsList.ItemsSource = Db.SearchBookings(fullNameText.Text, 
                                    startDate.Value, checkIn.Value);

    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        startDatePicker.SelectedDate = DateTime.Now;
    }

    private void CheckInButtonClick(object sender, RoutedEventArgs e)
    {
        var checkInForm = App.Provider.GetService<CheckInForm>();
        var model = (BookingFullModel)((Button)e.Source).DataContext;
        checkInForm.PopulateInformation(model);
        checkInForm.Show();
    }
}

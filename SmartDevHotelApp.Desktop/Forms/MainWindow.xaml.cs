namespace SmartDevHotelApp.Desktop;

public partial class MainWindow : Window
{
    private readonly IDatabaseData Db;

    public MainWindow(IDatabaseData db)
    {
        InitializeComponent();
        Db = db;
    }

    private void RoomSearchButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var form = App.Provider.GetRequiredService<RoomSearchForm>();

        if (form is null)
            return;

        form.Show();
    }

    private void BookingSearchButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var form = App.Provider.GetService<SearchForBookingsForm>();

        if (form is null)
            return;

        form.Show();
    }

    private void RoomManagementButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var form = App.Provider.GetService<RoomManagementForm>();

        if(form is null) 
            return;

        form.Show();
    }

    private void GuestManagemtnButtonClick(
            object sender, 
            RoutedEventArgs e)
    {
        var form = App.Provider.GetService<GuestManagementForm>();

        if(form is null)
            return;

        form.Show();
    }
}
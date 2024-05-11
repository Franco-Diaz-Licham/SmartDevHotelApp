namespace SmartDevHotelApp.Desktop;

public partial class App : Application
{
    public static ServiceProvider Provider { get; private set; }

    protected override void OnStartup(
            StartupEventArgs e)
    {
        base.OnStartup(e);

        var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");

        var services = new ServiceCollection();

        // forms
        services.AddTransient<MainWindow>();
        services.AddTransient<CheckInForm>();
        services.AddTransient<BookingForm>();
        services.AddTransient<RoomSearchForm>();
        services.AddTransient<RoomManagementForm>();
        services.AddTransient<SearchForBookingsForm>();
        services.AddTransient<GuestManagementForm>();

        // services
        IConfiguration config = builder.Build();

        services.AddSingleton(config);
        services.AddTransient<ISqlDataAccess, SqlDataAccess>();
        services.AddTransient<IDatabaseData, SqlData>();

        // set main window to start
        Provider = services.BuildServiceProvider();
        var window = Provider.GetService<MainWindow>();
        window.Show();
    }
}

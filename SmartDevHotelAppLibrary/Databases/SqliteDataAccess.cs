namespace SmartDevHotelAppLibrary.Databases;

public class SqliteDataAccess : ISqliteDataAccess
{
    private readonly IConfiguration Config;

    public SqliteDataAccess(IConfiguration config)
    {
        Config = config;
    }

    public List<T> LoadData<T, U>(
            string sql,
            U par,
            string cnx)
    {
        string conn = Config.GetConnectionString(cnx)!;

        using (IDbConnection connection = new SQLiteConnection(conn))
        {
            List<T> rows = connection.Query<T>(sql, par).ToList();
            return rows;
        }
    }

    public void SaveData<T>(
            string sql,
            T par,
            string cnx)
    {
        string conn = Config.GetConnectionString(cnx)!;

        using (IDbConnection connection = new SQLiteConnection(conn))
        {
            connection.Execute(sql, par);
        }
    }
}

namespace SmartDevHotelAppLibrary.Databases;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration Config;

    public SqlDataAccess(IConfiguration config)
    {
        Config = config;
    }

    public List<T> LoadData<T, U>(
            string sql,
            U par,
            string cnx,
            bool sp = false)
    {
        string conn = Config.GetConnectionString(cnx)!;
        CommandType ct = CommandType.Text;

        if (sp == true)
            ct = CommandType.StoredProcedure;

        using (IDbConnection connection = new SqlConnection(conn))
        {
            List<T> rows = connection.Query<T>(sql, par, commandType: ct).ToList();
            return rows;
        }
    }

    public void SaveData<T>(
            string sql,
            T par,
            string cnx,
            bool sp = false)
    {
        string conn = Config.GetConnectionString(cnx)!;
        CommandType ct = CommandType.Text;

        if (sp == true)
            ct = CommandType.StoredProcedure;

        using (IDbConnection connection = new SqlConnection(conn))
        {
            connection.Execute(sql, par, commandType: ct);
        }
    }
}

namespace SmartDevHotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sql, U par, string cnx, bool sp = false);
        void SaveData<T>(string sql, T par, string cnx, bool sp = false);
    }
}
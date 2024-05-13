
namespace SmartDevHotelAppLibrary.Databases
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T, U>(string sql, U par, string cnx);
        void SaveData<T>(string sql, T par, string cnx);
    }
}
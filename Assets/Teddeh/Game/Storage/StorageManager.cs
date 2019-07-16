namespace Teddeh.Game.Storage
{
    public class StorageManager
    {
        private static UserStorage _userStorage = new UserStorage();
        private static VehicleStorage _vehicleStorage = new VehicleStorage();

        public static UserStorage GetUserStorage()
        {
            return _userStorage;
        }
        
        public static VehicleStorage GetVehicleStorage()
        {
            return _vehicleStorage;
        }
    }
}
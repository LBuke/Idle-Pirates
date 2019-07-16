using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Teddeh.Game.Utility;
using Teddeh.Game.Vehicle;
using UnityEngine;

namespace Teddeh.Game.Storage
{
    public class VehicleStorage : IGameStorage<List<Vehicle.Vehicle>, List<VehicleData>>
    {
        public void Save(List<Vehicle.Vehicle> element)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + GetStorageFileName() + "." + FileUtility.STORAGE_FILE_EXTENSION;
            FileStream fileStream = new FileStream(path, FileMode.Create);
            
            List<VehicleData> vehicleDataList = new List<VehicleData>();
            foreach (Vehicle.Vehicle vehicle in element)
            {
                vehicleDataList.Add(vehicle.data);
            }

            binaryFormatter.Serialize(fileStream, vehicleDataList);
            fileStream.Close();
        }

        public List<VehicleData> Load()
        {
            string path = Application.persistentDataPath + "/" + GetStorageFileName() + "." + FileUtility.STORAGE_FILE_EXTENSION;
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                List<VehicleData> vehicleDataArray = binaryFormatter.Deserialize(fileStream) as List<VehicleData>;
                fileStream.Close();
                
                Debug.Log("Vehicle storage file " + path);
                
                return vehicleDataArray;
            }

            Debug.LogError("File not found in " + path);
            return null;
        }

        public string GetStorageFileName()
        {
            return "vehicles";
        }
    }
}
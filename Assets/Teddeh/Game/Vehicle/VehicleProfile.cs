using System.Collections.Generic;
using Teddeh.Game.Profile;
using Teddeh.Game.Storage;
using UnityEngine;

namespace Teddeh.Game.Vehicle
{
    public class VehicleProfile : ForeignProfile, IStorable
    {
        public List<Vehicle> VehicleList = new List<Vehicle>();

        private VehicleManager _vehicleManager;

        public VehicleProfile(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public void Load()
        {
            List<VehicleData> vehicleDataList = StorageManager.GetVehicleStorage().Load();

            GameObject parent = GameObject.Find("Vehicles");
            Vehicle vehicle;

            if (vehicleDataList != null)
            {
                foreach (VehicleData vehicleData in vehicleDataList)
                {
                    GameObject gameObject = Object.Instantiate(_vehicleManager.vehiclePrefabs[vehicleData.vehicleId], new Vector3(0, 0, 0), Quaternion.identity);
                    gameObject.transform.parent = parent.transform;
                    gameObject.transform.position = new Vector3(
                        vehicleData.position[0],
                        vehicleData.position[1],
                        vehicleData.position[2]
                    );

                    vehicle = gameObject.AddComponent<Vehicle>();
                    vehicle.data = vehicleData;

                    VehicleList.Add(vehicle);
                }
                return;
            }

            vehicle = CreateNewVehicle(1);
            VehicleList.Add(vehicle);
            
            Save();
        }

        public Vehicle CreateNewVehicle(int vehicleId)
        {
            var parent = GameObject.Find("Vehicles");

            var baseVehicle = VehicleRegistry.getById(vehicleId);
            if (baseVehicle == null)
                return null;
            
            var obj = Object.Instantiate(_vehicleManager.vehiclePrefabs[vehicleId], new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = parent.transform;
            var position = new Vector3(0, 0, 0);
            obj.transform.position = position;

            var data = new VehicleData();
            data.uniqueId = VehicleList.Count + 1;
            data.vehicleId = vehicleId;
            data.position = new float[3];
            data.position[0] = position.x;
            data.position[1] = position.y;
            data.position[2] = position.z;
            data.members = baseVehicle.members;
            
            Vehicle vehicle = obj.AddComponent<Vehicle>();
            vehicle.data = data;

            return vehicle;
        }

        public void Save()
        {
            StorageManager.GetVehicleStorage().Save(VehicleList);
        }

        public int GetProfileId()
        {
            return 1;
        }

//        public override bool Equals(object obj)
//        {
//            
//            return t;
//        }
//
//        public override int GetHashCode()
//        {
//            return t;
//        }
    }
}
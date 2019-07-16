using System;

namespace Teddeh.Game.Vehicle
{
    [Serializable]
    public class VehicleData
    {
        public int uniqueId;
        
        public int vehicleId;

        public float[] position;
        
        public int members;

        public VehicleData() {}

        public VehicleData(int uniqueId, int vehicleId, float[] position, int members)
        {
            this.uniqueId = uniqueId;
            this.vehicleId = vehicleId;
            this.position = position;
            this.members = members;
        }
    }
}
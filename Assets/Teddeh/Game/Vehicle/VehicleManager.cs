using System;
using System.Collections.Generic;
using Teddeh.Game.Item;
using Teddeh.Game.Storage;
using Teddeh.Game.Utility;
using UnityEngine;

namespace Teddeh.Game.Vehicle
{
    public class VehicleManager : MonoBehaviour
    {
        public Dictionary<int, GameObject> vehiclePrefabs;

        private void Awake()
        {
            VehicleRegistry.init();
        }
    }
}
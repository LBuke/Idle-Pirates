using System.Collections.Generic;
using Teddeh.Game.Item;
using Teddeh.Game.Utility;
using TMPro;
using UnityEngine;

namespace Teddeh.Game.Vehicle
{
    public class VehicleRegistry
    {
        private static List<GameVehicle> _vehicles = new List<GameVehicle>();

        
        public static void init()
        {
            GameVehicle rowing = ScriptableObject.CreateInstance<GameVehicle>();
            rowing.id = 1;
            rowing.name = "Rowing Boat";
            rowing.rarity = Rarity.UNCOMMON;
            rowing.members = 5;
            rowing.sails = 0;
            register(rowing);
            
            GameVehicle sloop = ScriptableObject.CreateInstance<GameVehicle>();
            sloop.id = 2;
            sloop.name = "Sloop";
            sloop.rarity = Rarity.COMMON;
            sloop.members = 7;
            sloop.sails = 0;
            register(sloop);
            
            GameVehicle cutter = ScriptableObject.CreateInstance<GameVehicle>();
            cutter.id = 3;
            cutter.name = "Cutter";
            cutter.rarity = Rarity.COMMON;
            cutter.members = 16;
            cutter.sails = 1;
            register(cutter);
            
            GameVehicle schooner = ScriptableObject.CreateInstance<GameVehicle>();
            schooner.id = 4;
            schooner.name = "Schooner";
            schooner.rarity = Rarity.RARE;
            schooner.members = 28;
            schooner.sails = 3;
            register(schooner);
            
            GameVehicle brig = ScriptableObject.CreateInstance<GameVehicle>();
            brig.id = 5;
            brig.name = "Brig";
            brig.rarity = Rarity.EPIC;
            brig.members = 46;
            brig.sails = 4;
            register(brig);
            
            GameVehicle warship = ScriptableObject.CreateInstance<GameVehicle>();
            warship.id = 6;
            warship.name = "Warship";
            warship.rarity = Rarity.LEGENDARY;
            warship.members = 64;
            warship.sails = 4;
            register(warship);
        }

        public static void register(GameVehicle vehicle)
        {
            if (vehicle == null)
                return;

            foreach (GameVehicle v in _vehicles)
            {
                if (vehicle.id == v.id)
                    return;
            }
            
            _vehicles.Add(vehicle);
        }

        public static GameVehicle getById(int id)
        {
            if (id < 1) id = 1;
            
            foreach (GameVehicle v in _vehicles)
            {
                if (id == v.id)
                    return v;
            }

            return null;
        }
    }
}
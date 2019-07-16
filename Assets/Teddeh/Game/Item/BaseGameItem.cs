using UnityEngine;

namespace Teddeh.Game.Item
{
    public class BaseGameItem : ScriptableObject
    {
        public int id;
        public new string name;
        public string description;

        public Utility.Rarity rarity;
    }
}
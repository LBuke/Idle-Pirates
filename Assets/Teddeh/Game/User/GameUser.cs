using System;
using System.Collections.Generic;
using Teddeh.Game.Profile;
using Teddeh.Game.Storage;
using UnityEngine;

namespace Teddeh.Game.User
{
    public class GameUser : MonoBehaviour, User, IStorable
    {
        private Dictionary<Type, ForeignProfile> _foreignProfiles;

        private UserData _userData;

        public UserData GetUserData()
        {
            return _userData;
        }

        public void Load()
        {
            var data = StorageManager.GetUserStorage().Load();
            
            if (data == null)
            {
                _userData = new UserData();
                Save();
                return;
            }

            _userData = data;
        }

        public void Save()
        {
            StorageManager.GetUserStorage().Save(this);
        }

        public bool RegisterForeignProfile<K, V>(V profile) where K : Type where V : ForeignProfile
        {
            if (!_foreignProfiles.ContainsKey(profile.GetType()))
            {
                _foreignProfiles.Add(profile.GetType(), profile);
                return true;
            }

            return false;
        }

        public V GetForeignProfile<K, V>(K type) where K : Type where V : ForeignProfile
        {
            if (_foreignProfiles.ContainsKey(type))
            {
                return (V) _foreignProfiles[type];
            }

            return default(V);
        }
    }
}
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Teddeh.Game.User;
using Teddeh.Game.Utility;
using UnityEngine;

namespace Teddeh.Game.Storage
{
    public class UserStorage : IGameStorage<User.User, UserData>
    {
        public void Save(User.User element)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + GetStorageFileName() + "." + FileUtility.STORAGE_FILE_EXTENSION;
            FileStream fileStream = new FileStream(path, FileMode.Create);

            binaryFormatter.Serialize(fileStream, element.GetUserData());
            fileStream.Close();
        }

        public UserData Load()
        {
            string path = Application.persistentDataPath + "/" + GetStorageFileName() + "." + FileUtility.STORAGE_FILE_EXTENSION;
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                UserData userData = binaryFormatter.Deserialize(fileStream) as UserData;
                fileStream.Close();
                
                Debug.Log("User storage file " + path);
                
                return userData;
            }

            Debug.LogError("File not found in " + path);
            return null;
        }

        public string GetStorageFileName()
        {
            return "user";
        }
    }
}
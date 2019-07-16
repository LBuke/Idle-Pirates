using System;

namespace Teddeh.Game.User
{
    [Serializable]
    public class UserData
    {
        public int level = 1;

        public UserData() {}

        public UserData(int level)
        {
            this.level = level;
        }
    }
}
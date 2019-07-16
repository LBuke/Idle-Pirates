namespace Teddeh.Game.User
{
    public interface User : Profile.Profile
    {
        UserData GetUserData();
    }
}
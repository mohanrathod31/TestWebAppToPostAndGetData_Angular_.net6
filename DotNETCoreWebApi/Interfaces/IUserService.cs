using DotNETCoreWebApi.Models;

namespace DotNETCoreWebApi.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserModel person);
        List<UserModel> GetUserList();
    }
}

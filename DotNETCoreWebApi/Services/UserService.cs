using DotNETCoreWebApi.Interfaces;
using DotNETCoreWebApi.Models;
using Newtonsoft.Json;

namespace DotNETCoreWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IFileHelper _fileHelper;
        public UserService(IFileHelper helper)
        {
            _fileHelper = helper;
        }
        public void AddUser(UserModel user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var users = GetUserList();
            if (users == null)
                users = new List<UserModel>();

            users.Add(user);
            _fileHelper.WriteFile(JsonConvert.SerializeObject(users));
        }

        public List<UserModel> GetUserList()
        {
            return _fileHelper.ReadFile<UserModel>();
        }
    }
}

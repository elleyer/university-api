using System.Threading.Tasks;
using Admin.Models.User;

namespace Admin.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateUser(string uname, string password);
        Task<User> RequestRegister(RegistrationModel model);
    }
}
using System.Threading.Tasks;
using Admin.Models.Mod;

namespace Admin.Services
{
    public interface IModService
    {
        Task<ModEntity> AuthenticateUser(string uname, string password);
        Task<ModEntity> RequestRegister(RegistrationModel model);
    }
}
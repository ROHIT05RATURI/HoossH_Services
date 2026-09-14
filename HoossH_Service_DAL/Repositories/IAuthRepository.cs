using HoossH_Service_DAL.Models;
using System.Threading.Tasks;

namespace HoossH_Service_DAL.Repositories
{
    public interface IAuthRepository
    {
        Task<LoginUser?> AuthenticateAsync(string username, string password);
    }
}

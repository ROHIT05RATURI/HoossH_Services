using HoossH_Service_DAL.Models;
using System;
using System.Threading.Tasks;

namespace HoossH_Service_DAL.Repositories
{
    public interface IAuthRepository
    {
        Task<LoginUser?> AuthenticateAsync(string username, string password);

        Task<bool> IsUsernameTakenAsync(string newUsername, Guid currentUserId);

        // Naye alag-alag methods
        Task<bool> UpdatePasswordAsync(Guid loginId, string oldUsername, string oldPasswordHash, string newPasswordHash);
        Task<bool> UpdateUsernameAsync(Guid loginId, string oldUsername, string oldPasswordHash, string newUsername);
    }
}
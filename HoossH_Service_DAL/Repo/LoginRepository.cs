    using Dapper;
    using HoossH_Service_DAL.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Microsoft.Identity.Client;

namespace HoossH_Service_DAL.Repositories
    {
        public class LoginRepository : IAuthRepository
        {
            private readonly string _connectionString;

            public LoginRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection") 
                    ?? throw new System.ArgumentNullException("DefaultConnection string is missing");
            }

            public async Task<LoginUser?> AuthenticateAsync(string username, string password)
            {
                var query = "SELECT loginid, username, active, hashpassword FROM LoginCredentials WHERE username = @Username AND active = 1";

                using var connection = new SqlConnection(_connectionString);

                var user = await connection.QuerySingleOrDefaultAsync<LoginUser>(query, new { Username = username });

                if (user != null && !string.IsNullOrEmpty(user.hashpassword))
                {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(user, user.hashpassword,password);

                    if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        return user;
                    }
                }

                return null; 
            }

        // 2. NAYA METHOD: Check Duplicate Username
        public async Task<bool> IsUsernameTakenAsync(string newUsername, Guid currentUserId)
        {
            // Ye check karega ki naya username DB me kisi aur user ke paas toh nahi hai (Active users me)
            var query = "SELECT COUNT(1) FROM LoginCredentials WHERE username = @Username AND loginid != @UserId AND active = 1";

            using var connection = new SqlConnection(_connectionString);
            var count = await connection.ExecuteScalarAsync<int>(query, new { Username = newUsername, UserId = currentUserId });

            return count > 0;
        }

        // 3. NAYA METHOD: Update Password
        public async Task<bool> UpdatePasswordAsync(Guid loginId, string oldUsername, string oldPasswordHash, string newPasswordHash)
        {
            // WHERE clause mein LoginId, OldUsername aur OldPasswordHash teeno check honge security ke liye
            string query = @"
                UPDATE LoginCredentials 
                SET hashpassword = @NewPasswordHash 
                WHERE loginid = @LoginId 
                  AND username = @OldUsername 
                  AND hashpassword = @OldPasswordHash 
                  AND active = 1";

            using var connection = new SqlConnection(_connectionString);
            int rowsAffected = await connection.ExecuteAsync(query, new
            {
                NewPasswordHash = newPasswordHash,
                LoginId = loginId,
                OldUsername = oldUsername,
                OldPasswordHash = oldPasswordHash
            });

            return rowsAffected > 0;
        }

        // 4. NAYA METHOD: Update Username
        public async Task<bool> UpdateUsernameAsync(Guid loginId, string oldUsername, string oldPasswordHash, string newUsername)
        {
            // WHERE clause mein LoginId, OldUsername aur OldPasswordHash teeno check honge security ke liye
            string query = @"
                UPDATE LoginCredentials 
                SET username = @NewUsername 
                WHERE loginid = @LoginId 
                  AND username = @OldUsername 
                  AND hashpassword = @OldPasswordHash 
                  AND active = 1";

            using var connection = new SqlConnection(_connectionString);
            int rowsAffected = await connection.ExecuteAsync(query, new
            {
                NewUsername = newUsername,
                LoginId = loginId,
                OldUsername = oldUsername,
                OldPasswordHash = oldPasswordHash
            });

            return rowsAffected > 0;
        }


    }
    }

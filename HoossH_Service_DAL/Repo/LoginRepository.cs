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
        }
    }

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoossH_Service_DAL.Models;

namespace HoossH_Service_DAL.Repo
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly string _connectionString;

        public AttendanceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> MarkCheckInAsync(Guid loginId, string location)
        {
            var query = @"IF NOT EXISTS (SELECT 1 FROM attendance WHERE LoginId = @LoginId AND [date] = CAST(GETDATE() AS DATE))
                      BEGIN
                          INSERT INTO attendance ([date], checkInTime, attendanceStatus, CheckInLocation, LoginId) 
                          VALUES (CAST(GETDATE() AS DATE), GETDATE(), 'Present', @Location, @LoginId)
                      END";

            using var connection = new SqlConnection(_connectionString);
            var rows = await connection.ExecuteAsync(query, new { LoginId = loginId, Location = location });
            return rows > 0;
        }

        public async Task<List<Attendance>> GetUserAttendanceAsync(Guid loginId)
        {
            var query = @"
                SELECT 
                    [date] AS Date,              
                    attendanceStatus AS Status, 
                    checkInTime AS Checkintime,
                    checkOutTime AS CheckoutTime,
                    CheckInLocation AS location,
                    CheckOutDescription AS description,
                    CASE WHEN checkOutTime IS NOT NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS isCheckedout
                FROM attendance 
                WHERE LoginId = @LoginId";

            using var connection = new SqlConnection(_connectionString);
            var result = await connection.QueryAsync<Attendance>(query, new { LoginId = loginId });

            return result.AsList();
        }

        public async Task<bool> MarkCheckOutAsync(Guid loginId, string location, string description)
        {
            var query = @"
                UPDATE attendance 
                SET checkOutTime = GETDATE(), CheckOutLocation = @Location, CheckOutDescription = @Description
                WHERE Id = (
                    SELECT TOP 1 Id FROM attendance 
                    WHERE LoginId = @LoginId AND checkOutTime IS NULL 
                    ORDER BY [date] DESC
                )";

            using var connection = new SqlConnection(_connectionString);
            var rows = await connection.ExecuteAsync(query, new { LoginId = loginId, Location = location, Description = description });
            return rows > 0;
        }
    }
}
using HoossH_Service_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoossH_Service_DAL.Repo
{
   public interface IAttendanceRepository
    {
        Task<bool> MarkCheckInAsync(Guid loginId, string location);
        Task<bool> MarkCheckOutAsync(Guid loginId, string location, string description);
        Task<List<Attendance>> GetUserAttendanceAsync(Guid loginId);
    }
    
}

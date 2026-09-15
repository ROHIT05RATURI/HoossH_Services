namespace HoossH_Services.Models
{
    public class ManagerAttendance
    {
        public List<Attendence> attendences = new List<Attendence>();

        public List<Attendence> Summary = new List<Attendence>();

        public List<Leaves> leaves = new List<Leaves>();

        public List<Leaves> LeavesHistory = new List<Leaves>();

        public string selectedMonth { get; set; }
    }
}

namespace HoossH_Services.Models
{
    public class Client
    {
        public List<Customer> Customers { get; set; }
        public List<Designation> Designations { get; set; }
    }

    public class Customer
    {
        public string CustomerName { get; set; }
        public string Industry { get; set; }
    }

    public class Designation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}

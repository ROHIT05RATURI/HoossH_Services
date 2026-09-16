using HoossH_Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoutes()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Addproduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            return View("Addproduct", model);
        }

        public IActionResult CustomerReport(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("Index");
            }

            int.TryParse(customerId.ToUpper().Replace("CUST", ""), out int parsedCustomerId);
            var model = new CustomerKundli
            {
                CustomerId = parsedCustomerId,
                FunnelVisits = 150,
                FunnelEnquiries = 100,
                FunnelQualified = 60,
                FunnelOrders = 30,
                FunnelRepeat = 10,
                TotalOrderValue = 500000,
                value = "False",
                customerDetails = new CustomerDetails
                {
                    OrganizationName = "Tech Innovators Inc.",
                    Industry = "Software",
                    CustomerAddress = "123 Tech Park, Silicon Valley, CA",
                    CustomerGst = "GSTIN123456789",
                    UserProjection = 1000000
                },
                visitInfo = new VisitInfo
                {
                    CurrentYearVisit = 25,
                    FinancialYearOrdersCount = 12,
                    FinancialYearEnquiriesValue = 850000,
                    FinancialYearEnquiriesCount = 45,
                    FinancialYearLeadValue = 400000,
                    FinancialYearLeadCount = 20
                },
                timeline = new List<TimelineItem>
        {
            new TimelineItem { Alignment = "left", ThemeColor = "blue", Title = "Initial Meeting", DateAndLocation = "10 Jan 2026 - Office", DaysGapToNext = 15 },
            new TimelineItem { Alignment = "right", ThemeColor = "green", Title = "Follow up", DateAndLocation = "25 Jan 2026 - Call", DaysGapToNext = null }
        },
                FunnelMetrics = new FunnelMetrics
                {
                    TotalVisits = 150,
                    Enquiries = 100,
                    QualifiedLeads = 60,
                    OrdersWon = 30,
                    RepeatOrders = 10
                },
                CustomerOrderData = new List<CustomerOrder>
        {
            new CustomerOrder { QuotationSeries = "QT-001", BillNumber = "BILL-001", Date = "15 Feb 2026", Amount = 150000, Status = "Completed" }
        },
                Leads = new List<Lead>
        {
            new Lead { Series = "LD-101", Id = 1, ModuleName = "Software License", Amount = 200000 }
        },
                Enquiries = new List<Enquiry>
        {
            new Enquiry { QuotationSeries = "QT-002", Date = "20 Feb 2026", Amount = 50000 }
        },
                Payments = new List<Payment>
        {
            new Payment { Series = "PAY-01", InvoiceNumber = "INV-001", Date = "10 Mar 2026", TotalAmount = 150000, Status = "FULL PAID", PendingAmount = 0 }
        },
                Feedbacks = new List<Feedback>
        {
            new Feedback { ReferenceId = "FB-123", Date = "01 Mar 2026", Rating = 5, Comment = "Excellent service!" }
        },
                Competitor = new CompetitorInfo
                {
                    KeyCompetitor = "Rival Corp",
                    OurAdvantage = "Better Support",
                    LastDealStatus = "Won"
                },
                Swot = new SwotAnalysis
                {
                    StrengthText = "Market Leader",
                    StrengthSubText = "Strong brand presence",
                    WeaknessText = "High Cost",
                    WeaknessSubText = "Premium pricing",
                    OpportunityText = "New Markets",
                    OpportunitySubText = "Expansion to EU",
                    ThreatText = "New Entrants",
                    ThreatSubText = "Startups disrupting"
                },
                Notes = new List<SpecialNote>
        {
            new SpecialNote { AddedBy = "John Doe", Date = "15 Jan 2026", NoteText = "Client prefers email communication." }
        },
                Contacts = new List<ContactDirectory>
        {
            new ContactDirectory { ThemeColor = "blue", IconClass = "fas fa-user", contactPersonName = "Alice Smith", designations = "CTO", contactNumber = "+1-555-1234" }
        },
                MonthLabels = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun" },
                MonthlySales = new List<long> { 1, 2, 1, 3, 2, 4 },
                MonthlySalesValues = new List<long> { 10000, 20000, 15000, 30000, 25000, 40000 },
                MonthlyEnquiries = new List<int> { 5, 8, 4, 10, 6, 12 },
                MonthlyEnquiriesVlaues = new List<long> { 5000, 8000, 4000, 10000, 6000, 12000 },
                MonthlyQualifiedLeads = new List<int> { 2, 4, 2, 5, 3, 6 },
                MonthlyQualifiedLeadsValues = new List<long> { 2000, 4000, 2000, 5000, 3000, 6000 },
                PaymentsReceived = new List<long> { 5000, 15000, 10000, 25000, 20000, 30000 },
                PaymentsPending = new List<long> { 5000, 5000, 5000, 5000, 5000, 10000 }
            };

            return View(model);
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;

namespace HoossH_Services.Models
{
    public class CustomerKundli
    {
        public int CustomerId { get; set; }
        public int FunnelVisits { get; set; }
        public int FunnelEnquiries { get; set; }
        public int FunnelQualified { get; set; }
        public int FunnelOrders { get; set; }
        public int FunnelRepeat { get; set; }
        public string value { get; set; }

        public CustomerDetails customerDetails { get; set; } = new CustomerDetails();
        public long TotalOrderValue { get; set; }
        public VisitInfo visitInfo { get; set; } = new VisitInfo();
        
        public List<TimelineItem> timeline { get; set; } = new List<TimelineItem>();
        public FunnelMetrics FunnelMetrics { get; set; } = new FunnelMetrics();
        public List<CustomerOrder> CustomerOrderData { get; set; } = new List<CustomerOrder>();
        public List<Lead> Leads { get; set; } = new List<Lead>();
        public List<Enquiry> Enquiries { get; set; } = new List<Enquiry>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public CompetitorInfo Competitor { get; set; } = new CompetitorInfo();
        public SwotAnalysis Swot { get; set; } = new SwotAnalysis();
        public List<SpecialNote> Notes { get; set; } = new List<SpecialNote>();
        public List<ContactDirectory> Contacts { get; set; } = new List<ContactDirectory>();

        // Chart Data properties
        public List<string> MonthLabels { get; set; } = new List<string>();
        public List<long> MonthlySales { get; set; } = new List<long>();
        public List<long> MonthlySalesValues { get; set; } = new List<long>();
        public List<int> MonthlyEnquiries { get; set; } = new List<int>();
        public List<long> MonthlyEnquiriesVlaues { get; set; } = new List<long>();
        public List<int> MonthlyQualifiedLeads { get; set; } = new List<int>();
        public List<long> MonthlyQualifiedLeadsValues { get; set; } = new List<long>();
        
        public List<int> MonthlyProspects { get; set; } = new List<int>();
        public List<int> MonthlyClients { get; set; } = new List<int>();
        public List<long> MonthlyIncentives { get; set; } = new List<long>();
        public List<long> PaymentsReceived { get; set; } = new List<long>();
        public List<long> PaymentsPending { get; set; } = new List<long>();
    }

    public class CustomerDetails
    {
        public long UserProjection { get; set; }
        public string OrganizationName { get; set; }
        public string Industry { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGst { get; set; }
    }

    public class VisitInfo
    {
        public int CurrentYearVisit { get; set; }
        public int FinancialYearOrdersCount { get; set; }
        public long FinancialYearEnquiriesValue { get; set; }
        public int FinancialYearEnquiriesCount { get; set; }
        public long FinancialYearLeadValue { get; set; }
        public int FinancialYearLeadCount { get; set; }
    }

    public class TimelineItem
    {
        public string Alignment { get; set; } // "left" or "right"
        public string ThemeColor { get; set; }
        public string Title { get; set; }
        public string DateAndLocation { get; set; }
        public int? DaysGapToNext { get; set; }
    }

    public class FunnelMetrics
    {
        public int TotalVisits { get; set; }
        public int Enquiries { get; set; }
        public int QualifiedLeads { get; set; }
        public int OrdersWon { get; set; }
        public int RepeatOrders { get; set; }
    }

    public class CustomerOrder
    {
        public string QuotationSeries { get; set; }
        public string BillNumber { get; set; }
        public string Date { get; set; }
        public long Amount { get; set; }
        public string Status { get; set; }
    }

    public class Lead
    {
        public string Series { get; set; }
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public long Amount { get; set; }
    }

    public class Enquiry
    {
        public string QuotationSeries { get; set; }
        public string Date { get; set; }
        public long Amount { get; set; }
    }

    public class Payment
    {
        public string Series { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
        public long TotalAmount { get; set; }
        public string Status { get; set; }
        public long PendingAmount { get; set; }
    }

    public class Feedback
    {
        public string ReferenceId { get; set; }
        public string Date { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class CompetitorInfo
    {
        public string KeyCompetitor { get; set; }
        public string OurAdvantage { get; set; }
        public string LastDealStatus { get; set; }
    }

    public class SwotAnalysis
    {
        public string StrengthText { get; set; }
        public string StrengthSubText { get; set; }
        public string WeaknessText { get; set; }
        public string WeaknessSubText { get; set; }
        public string OpportunityText { get; set; }
        public string OpportunitySubText { get; set; }
        public string ThreatText { get; set; }
        public string ThreatSubText { get; set; }
    }

    public class SpecialNote
    {
        public string AddedBy { get; set; }
        public string Date { get; set; }
        public string NoteText { get; set; }
    }

    public class ContactDirectory
    {
        public string ThemeColor { get; set; }
        public string IconClass { get; set; }
        public string contactPersonName { get; set; }
        public string designations { get; set; }
        public string contactNumber { get; set; }
    }
}

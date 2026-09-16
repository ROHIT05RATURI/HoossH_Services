using System;
using System.Collections.Generic;

namespace HoossH_Services.Models
{
    public class Kundali
    {
        public decimal TargetTillDate { get; set; }
        public decimal TotalAchievedSoFar { get; set; }
        public decimal AnnualTarget { get; set; }
        public int FunnelVisits { get; set; }
        public int FunnelEnquiries { get; set; }
        public int FunnelQualified { get; set; }
        public int FunnelOrders { get; set; }
        public int FunnelRepeat { get; set; }
        
        public List<MonthlySalesSummaryData> MonthlySalesSummary { get; set; }
        public List<MonthlyPaymentSummaryData> MonthlyPaymentSummary { get; set; }
        public List<MonthlyIncentiveSummaryData> MonthlyIncentiveSummary { get; set; }
        public List<MonthlyConversionData> ProspectToClientMonthly { get; set; }
        public List<MonthlyFunnelSummaryData> MonthlyFunnelSummary { get; set; }
        
        public List<string> MonthLabels { get; set; }
        public List<long> MonthlySales { get; set; }
        public List<decimal> MonthlySalesValues { get; set; }
        public List<long> MonthlyEnquiries { get; set; }
        public List<decimal> MonthlyEnquiriesVlaues { get; set; }
        public List<long> MonthlyQualifiedLeads { get; set; }
        public List<decimal> MonthlyQualifiedLeadsValues { get; set; }
        
        public List<IncentiveDataModel> IncentiveMonthly { get; set; }
        public List<long> PaymentsReceived { get; set; }
        public List<long> PaymentsPending { get; set; }
        
        public byte[] Avatar { get; set; }
        public string AgentName { get; set; }
        public string JoinDate { get; set; }
        public int DaysTogether { get; set; }
        public string KundliLoginID { get; set; }
        
        public int TotalVisits { get; set; }
        public int uniqueCustomers { get; set; }
        public decimal LiveEnquiriesValue { get; set; }
        public int LiveInquiry { get; set; }
        public decimal LiveQualifiedValue { get; set; }
        public int LiveQualifiedLead { get; set; }
        public decimal LiveOrdersValue { get; set; }
        public int LiveOrdersCount { get; set; }
        
        public YearlyData yearlydata { get; set; }
        public decimal TotalProjection { get; set; }
        
        public AttendanceData AttendanceData { get; set; }
        public int repeatCustomers { get; set; }
        public decimal RepeatCustomerPercentage { get; set; }

        public int CancelledEnquiriesCount { get; set; }
        public decimal CancelledEnquiriesValue { get; set; }
        public int TotalEnquiriesCount { get; set; }
        
        public int CancelledQualifiedCount { get; set; }
        public decimal CancelledQualifiedValue { get; set; }
        public int TotalQualifiedCount { get; set; }
        
        public int CancelledOrdersCount { get; set; }
        public decimal CancelledOrdersValue { get; set; }
        public int TotalOrders { get; set; }
    }

    public class MonthlySalesSummaryData {
        public string MonthLabel { get; set; }
        public decimal TotalOrdersValue { get; set; }
        public decimal PreviousMonthOrderValue { get; set; }
        public decimal Vairance { get; set; }
        public decimal ChangePercentage { get; set; }
    }
    public class MonthlyPaymentSummaryData {
        public string MonthLabel { get; set; }
        public decimal CurrentMonthPayment { get; set; }
        public decimal PreviousMonthPayment { get; set; }
        public decimal VarianceAmount { get; set; }
        public decimal VariancePercentage { get; set; }
        public decimal PendingPayments { get; set; }
    }
    public class MonthlyIncentiveSummaryData {
        public string MonthLabel { get; set; }
        public decimal CurrentMonthIncentive { get; set; }
        public decimal PreviousMonthIncentive { get; set; }
        public decimal VarianceAmount { get; set; }
        public decimal VariancePercentage { get; set; }
    }
    public class MonthlyConversionData {
        public string MonthLabel { get; set; }
        public int Clientsthismonth { get; set; }
        public int NewProspectsAdded { get; set; }
        public int RemainingProspects { get; set; }
        public int TotalProspects { get; set; }
        public int TotalClients { get; set; }
        public decimal ConversionRate { get; set; }
    }
    public class MonthlyFunnelSummaryData {
        public string MonthLabel { get; set; }
        public int EnquiriesCount { get; set; }
        public int QualifiedCount { get; set; }
        public int OrdersCount { get; set; }
        public decimal EnquiriesValue { get; set; }
        public decimal EnquiryVariancePercent { get; set; }
        public decimal QualifiedValue { get; set; }
        public decimal QualifiedVariancePercent { get; set; }
        public decimal OrdersValue { get; set; }
        public decimal OrdersVariancePercent { get; set; }
        public decimal UnqualifiedEnquiryPercent { get; set; }
        public int TotalEnquiriesCount { get; set; }
        public int TotalQualifiedCount { get; set; }
        public int TotalOrdersCount { get; set; }
        public decimal TotalEnquiriesValue { get; set; }
        public decimal TotalQualifiedValue { get; set; }
        public decimal TotalOrdersValue { get; set; }
        public decimal enquirytoQualified { get; set; }
        public decimal enquirytoOrder { get; set; }
    }
    public class IncentiveDataModel {
        public string MonthName { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class YearlyData {
        public decimal TotalPendingReceivable { get; set; }
        public int TotalUnpaidInvoices { get; set; }
        public decimal TotalOrderValue { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public string BestMonth { get; set; }
        public decimal BestMonthValue { get; set; }
        public int TotalProspectPool { get; set; }
        public int TotalClientsConverted { get; set; }
        public int RemainingProspects { get; set; }
        public decimal CurrentConversionRate { get; set; }
        public decimal TotalPaymentReceived { get; set; }
        public int TotalUnpaidClients { get; set; }
        public decimal TotalIncentiveEarned { get; set; }
        public decimal AverageIncentivePerMonth { get; set; }
        public string BestIncentiveMonth { get; set; }
        public decimal BestIncentiveMonthValue { get; set; }
    }
    public class AttendanceData {
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int leavesDays { get; set; }
        public int WeekendDays { get; set; }
        public decimal ScorePercentage { get; set; }
    }
}

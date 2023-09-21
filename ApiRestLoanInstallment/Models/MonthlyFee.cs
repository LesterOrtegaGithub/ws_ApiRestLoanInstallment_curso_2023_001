namespace ApiRestLoanInstallment.Models
{
    public class MonthlyFee
    {
        public int MonthlyFeeId { get; set; }
        public decimal Amount { get; set; }
        public int AnualRate { get; set; }
        public int Periodicity { get; set; }
        public decimal PercentRate { get; set; }

        public int Duration { get; set; }
        public decimal MontlyFee { get; set; }
    }
}

namespace Elite.Web.API.Others.DTOs
{
    public class InsuranceDTO
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int CompanyId { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public decimal AnnualFee { get; set; }
    }
}

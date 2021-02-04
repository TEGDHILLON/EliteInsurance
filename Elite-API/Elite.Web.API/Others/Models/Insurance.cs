using System;

namespace Elite.Web.API.Others.Models
{
    public class Insurance
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
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}

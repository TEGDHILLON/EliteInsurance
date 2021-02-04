using System;

namespace Elite.Web.API.Others.DTOs
{
    public class InsuranceInfoDTO
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public decimal AnnualFee { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}

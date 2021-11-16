namespace IraoAssignment.Shared
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } 
        public decimal CompanyPrice { get; set; }
        public Market MarketName { get; set; }
    }
}
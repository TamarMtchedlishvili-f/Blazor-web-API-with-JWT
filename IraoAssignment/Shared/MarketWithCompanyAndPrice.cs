namespace IraoAssignment.Shared
{
    public class MarketWithCompanyAndPrice : BaseEntity
    {
        public Market Market { get; set; }
        public Company Company { get; set; }
        public int CompanyPrice { get; set; }
    }
}
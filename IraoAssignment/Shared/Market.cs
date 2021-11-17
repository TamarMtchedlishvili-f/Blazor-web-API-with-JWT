namespace IraoAssignment.Shared
{
    public class Market : BaseEntity
    {
        public string MarketName { get; set; }

        public override string ToString() => MarketName;
    }
}
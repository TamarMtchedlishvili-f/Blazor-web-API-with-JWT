namespace IraoAssignment.Shared
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public override string ToString() => CompanyName;
    }
}
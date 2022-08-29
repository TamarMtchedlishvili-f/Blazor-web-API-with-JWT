using System.ComponentModel.DataAnnotations;

namespace IraoAssignment.Shared
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PapperAB.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = default!;
        [StringLength(25)]
        public string Address { get; set; } = default!;
        [StringLength(25)]
        public string City { get; set; } = default!;
        public virtual ICollection<ProjectList>? ProjectLists { get; set; }// Navigation
    }
}

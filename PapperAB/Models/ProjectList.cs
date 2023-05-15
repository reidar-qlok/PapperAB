

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PapperAB.Models
{
    public class ProjectList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectListId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime Stop { get; set; }
        [ForeignKey("Employees")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }//Navigering
        [ForeignKey("Projects")]
        public int FK_ProjectId { get; set; }
        public virtual Project Projects { get; set; }//navigering
    }
}

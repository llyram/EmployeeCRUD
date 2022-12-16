using System.ComponentModel.DataAnnotations;


namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        public string Designation { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public DateTime? RecordCreatedOn { get; set; }
    }
}

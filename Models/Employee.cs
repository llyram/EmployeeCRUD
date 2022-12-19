using System.ComponentModel.DataAnnotations;
using EmployeeCRUD.Utilities;


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
        [UniquePhoneValidation(ErrorMessage = "Phone number is already in use")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public DateTime? RecordCreatedOn { get; set; }
    }
}

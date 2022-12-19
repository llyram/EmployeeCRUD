using EmployeeCRUD.Data;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Utilities
{
    public class UniquePhoneValidation : ValidationAttribute
    {
        private readonly ApplicationDbContext _context;

        //public UniquePhoneValidation(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (_context.Employees.Any(x => x.PhoneNumber == value))
            {
                return new ValidationResult(ErrorMessage);
            }
            //var files = value as List<IFormFile>;
            //if (files != null)
            //{
            //    foreach (IFormFile file in files)
            //    {
            //        var extension = Path.GetExtension(file.FileName);
            //        if (!(extension == _extension))
            //        {
            //            return new ValidationResult(ErrorMessage);
            //        }
            //    }
            //}

            return ValidationResult.Success;
        }
    }
}
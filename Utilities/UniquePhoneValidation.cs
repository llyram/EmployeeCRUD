using EmployeeCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EmployeeCRUD.Utilities
{
    public class UniquePhoneValidation : RemoteAttribute
    {
        private readonly ApplicationDbContext _context;

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            // Get the Database Context
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            PropertyInfo additionalPropertyName =
            validationContext.ObjectInstance.GetType().GetProperty(AdditionalFields);

            // Get the value of ID
            object additionalPropertyValue =
            additionalPropertyName.GetValue(validationContext.ObjectInstance, null);

            // Check if the phone number already exists and if it does is it the same id
            bool validateName = _context.Employees.Any
            (x => x.PhoneNumber == (string)value && x.Id != (int)additionalPropertyValue);

            if (validateName)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
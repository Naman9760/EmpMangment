using System;
using System.ComponentModel.DataAnnotations;

namespace EmpMangment.Model
{
    public class EmployeeData
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage =" Use Letters Only Please")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = " Use Letters Only Please")]
        public string LastName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.PastDate))]
        public DateTime DateOfBirth { get; set; }
        [Required, Range(25, 99, ErrorMessage = "Please enter a age bigger than 25")]
        public int Age { get; set; }
        public string Designation { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.PastDate))]
        public DateTime DateOfJoining { get; set; }
        public int CTC { get; set; }



        public class CustomValidationMethods
        {
            public static ValidationResult PastDate(DateTime date)
            {
                return DateTime.Compare(date, DateTime.Today) > 0 ? new ValidationResult("Date cannot be in the future") : ValidationResult.Success;
            }

            public static ValidationResult FutuerDate(DateTime date)
            {
                return DateTime.Compare(date, DateTime.Today) < 0 ? new ValidationResult("Date cannot be in the future") : ValidationResult.Success;
            }
        }

    }
}

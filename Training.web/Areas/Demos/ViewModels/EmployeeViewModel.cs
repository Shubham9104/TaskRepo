using System;
using System.ComponentModel.DataAnnotations;

namespace Training.web.Areas.Demos.ViewModel
{
    public class EmployeeViewModel
    {
        [Display(Name = "Id of Employee:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [MaxLength(80, ErrorMessage = "{0} cannot be a maximum of {1} characters")]
        [MinLength(2, ErrorMessage = "{0} cannot be a minimum of {1} characters")]


        [Display(Name = "Name of Employee:")]
        public string EmployeeName { get; set; }
        [Required]

        [Display(Name = "DOB of Employee:")]
        public DateTime DateOfBirth { get; set; }

        [Range(minimum: 0, maximum: 2000000, ErrorMessage = "{0} has to  be between {1} and {2}")]

        [Display(Name = "Salary of Employee:")]
        public decimal Salary { get; set; }


        public bool IsEnabled { get; set; }

    }
}

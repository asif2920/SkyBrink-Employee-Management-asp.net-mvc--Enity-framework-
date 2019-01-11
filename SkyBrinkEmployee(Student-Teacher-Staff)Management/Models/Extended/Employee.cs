using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyBrinkEmployee_Student_Teacher_Staff_Management.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
    public class EmployeeMetaData
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        [Display(Name = "Department")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department Required")]
        public string Department { get; set; }
        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number Required")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Designation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Designation Required")]
        public string Designation { get; set; }
    }
}
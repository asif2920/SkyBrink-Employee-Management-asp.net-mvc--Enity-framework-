using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SkyBrinkEmployee_Student_Teacher_Staff_Management.Controllers;

namespace SkyBrinkEmployee_Student_Teacher_Staff_Management.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
       
    }

    public class StudentMetaData
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department Name is required")]
        public string Department { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
    }
}
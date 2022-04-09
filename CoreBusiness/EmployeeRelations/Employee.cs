using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.EmployeeRelations
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter Employee Code!")]
        [DisplayName("Employee Code")]
        [RegularExpression("[a-zA-Z0-9-_]+$", ErrorMessage = "Invalid character!")]
        [StringLength(10, ErrorMessage = "Code can be maximum of 10 characters!")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Please enter First Name!")]
        [DisplayName("First Name")]
        [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
        [StringLength(25, ErrorMessage = "First Name can be maximum of 25 characters!")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
        [StringLength(25, ErrorMessage = "First Name can be maximum of 25 characters!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name!")]
        [DisplayName("Last Name")]
        [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
        [StringLength(25, ErrorMessage = "Last Name can be maximum of 25 characters!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your name as per Aadhaar!")]
        [DisplayName("Name as per Aadhaar")]
        [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
        [StringLength(50, ErrorMessage = "Name as per Aadhaar can be maximum of 50 characters!")]
        public string NameAsAadhaar { get; set; }

        [Required(ErrorMessage = "Please enter Aadhaar Number!")]
        [DisplayName("Aadhaar No.")]
        [RegularExpression("[2-9]{1}[0-9]{11}$", ErrorMessage = "Invalid Aadhaar number!")]
        public string AadhaarNo { get; set; }

        [Required(ErrorMessage = "Please select Gender!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please provide you Birth Date!")]
        [DisplayName("Date of Birth")]
        public DateTime? DOB { get; set; }

        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        [DisplayName("Marriage Date")]
        public DateTime? MarriageDate { get; set; }
        public string Salutation { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }

        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }

        [DisplayName("Profile Picture")]
        public string ProfilePicPath { get; set; }

    }

}

using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Masters;
 
public class Company
{
    [Required(ErrorMessage = "Please enter description")]
    [StringLength(200, ErrorMessage = "Description can contain only 200 characters")]
    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Please enter valid description")]
    public string Description { get; set; }
   
    [Required(ErrorMessage = "Please enter short description")]
    [StringLength(100, ErrorMessage = "Short description can contain only 100 characters")]
    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Please enter valid short description")]
    public string ShortDescription { get; set; }
    
    [Required(ErrorMessage = "Please enter retirement age")]
    [Range(0, 60, ErrorMessage = "Retirement age should not contain characters")]
    public int RetirementAge { get; set; }
    
    public string Address { get; set; }

    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; }
    
    public string WebSite { get; set; }
    public string PhoneNo { get; set; }
    public string Mobile { get; set; }
    public string FiscalYearStart { get; set; }
    public string FiscalYearEnd { get; set; }
    public int DateFormatId { get; set; }
    public int PayPeriodStartMonth { get; set; }
    
    [StringLength(15, ErrorMessage = "GST Number  can contain only 15 characters")]
    [RegularExpression("^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Please enter valid GST number")]
    public string GSTNumber { get; set; }
    
    public string PayPeriodDisplayMonth { get; set; }
    public string DateFormatDisplay { get; set; }
    
    [Required(ErrorMessage = "Please enter user name")]
    [RegularExpression("[a-zA-Z0-9_]*$", ErrorMessage = "Invalid user name ")]
    [StringLength(100, ErrorMessage = "User name can contain only 100 characters")]
    public string UserName { get; set; }
    
    [StringLength(100, ErrorMessage = "Password can contain only 100 characters")]
    public string AuthenticationCode { get; set; }
    
    [Required(ErrorMessage = "Please enter Page Title")]
    [StringLength(50, ErrorMessage = "Page Title can contain only 50 characters")]
    public string PageTitle { get; set; }
    
    [Required(ErrorMessage = "Please select company logo")]
    public string CompanyLogoPath { get; set; }

}


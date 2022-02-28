using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Masters;

public class PayHead
{
    [Required(ErrorMessage = "Please enter  Code!")]
    [RegularExpression("[a-zA-Z0-9-_]+$", ErrorMessage = "Invalid character!")]
    [StringLength(10, ErrorMessage = "Code can be maximum of 10 characters!")]
    public string Code { get; set; }


    [Required(ErrorMessage = "Please enter Description")]
    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid Description ")]
    [StringLength(200, ErrorMessage = "Description can contain only 200 characters")]
    public string Description { get; set; }


    [Required(ErrorMessage = "Please enter Name!")]
    [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
    [StringLength(50, ErrorMessage = " Name can be maximum of 50 characters!")]
    public string Name { get; set; }

    public int Level { get; set; }
    public int PayHeadId { get; set; }
    public bool IsDeduction { get; set; }


    [Required(ErrorMessage = "Please enter Type!")]
    [RegularExpression("[a-zA-Z0-9 ']+$", ErrorMessage = "Invalid character!")]
    [StringLength(1, ErrorMessage = " Name can be maximum of 1 characters!")]
    public string Type { get; set; }
}


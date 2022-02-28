using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Masters;

public class Department
{
    public int DepartmentId { get; set; }

    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid department name ")]
    [StringLength(300, ErrorMessage = "Department can contain only 300 characters")]
    public string DepartmentName { get; set; }

    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid short descriptin name ")]
    [StringLength(150, ErrorMessage = "Short description can contain only 150 characters")]
    public string ShortDescription { get; set; }

    public string ACCode { get; set; }
    public int AllocationType { get; set; }
    public string AllocationCode { get; set; }
}


namespace CoreBusiness.Masters;

public class Designation
{
    public int DesignationId { get; set; }
    public int DepartmentId { get; set; }
    public int StaffCategoryId { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Frontline { get; set; }
    public string JobDescription { get; set; }
}

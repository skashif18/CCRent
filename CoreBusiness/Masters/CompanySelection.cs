using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Masters;

public class CompanySelection
{
    [Key]
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string ShortDescription { get; set; }
    public string PageTitle { get; set; }
    public string CompanyLogoPath { get; set; }
}


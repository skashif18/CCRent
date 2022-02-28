using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Masters
{
    public class Group
    {
		[RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid group name ")]
		[StringLength(200, ErrorMessage = "Group can contain only 200 characters")]
		public string GroupName { get; set; }
		
		[Required(ErrorMessage = "Please enter short decription")]
		[StringLength(100, ErrorMessage = "Short Description can contain only 100 characters")]
		public string ShortDescription { get; set; }
		
		public string GroupKey { get; set; }

		[Required(ErrorMessage = "Please enter email address")]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
		public string GroupEmail { get; set; }
		
		[Required(ErrorMessage = "Please enter page title")]
		[RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid page title")]
		[StringLength(100, ErrorMessage = "Page title can contain only 100 characters")]
		public string PageTitle { get; set; }
		
		public string UserName { get; set; }
		public string AuthenticationCode { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace MVC_BL.ViewModels
{
	public class ResetPassViewModel
	{
		[Required (ErrorMessage ="New Password Is Required")]
		[DataType (DataType.Password)]
		public string NewPassword { get; set; }
		[Required (ErrorMessage ="Confirm Password Is Required")]
		[DataType(DataType.Password)]
		[Compare("NewPassword",ErrorMessage = "Password Dosen't Match")]
		public string ConfirmPassword { get; set;}
    }
}

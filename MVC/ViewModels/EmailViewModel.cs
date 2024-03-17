using System.ComponentModel.DataAnnotations;

namespace MVC_BL.ViewModels
{
	public class EmailViewModel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "InValid Email")]
		public string Email { get; set; }
	}
}

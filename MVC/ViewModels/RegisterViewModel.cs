﻿using System.ComponentModel.DataAnnotations;

namespace MVC_BL.ViewModels
{
	public class RegisterViewModel
	{
        [Required (ErrorMessage ="FName Is Required")]
        
        public string FName { get; set; }
		[Required(ErrorMessage = "LName Is Required")]

		public string LName { get; set; }
		[Required(ErrorMessage = "Email Is Required")]
        [EmailAddress (ErrorMessage ="InValid Email")]
		public string Email { get; set; }
        [Required (ErrorMessage ="Password Is Required")]
        [DataType (DataType.Password)]

		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password Is Required")]
		[DataType(DataType.Password)]
		[Compare("Password" , ErrorMessage ="Password Dosen't Match ") ]
		public string ConfirmPassword { get; set; }
		[Required (ErrorMessage ="Has Required")]
        public bool IsAgree { get; set; }
    }
}

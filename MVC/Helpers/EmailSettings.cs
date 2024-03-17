using MVC_DAL.Models;
using System.Net;
using System.Net.Mail;

namespace MVC_BL.Helpers
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var Client = new SmtpClient("smtp.gmail.com", 587);
			Client.EnableSsl = true;
			Client.Credentials = new NetworkCredential("djvjtxgfj@gmail.com", "bomfzmwcuawtxpkv");
			Client.Send("djvjtxgfj@gmail.com", email.To, email.Subject, email.Body);
		}
	}
}

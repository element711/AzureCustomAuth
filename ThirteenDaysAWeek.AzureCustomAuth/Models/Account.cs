using Newtonsoft.Json;

namespace ThirteenDaysAWeek.AzureCustomAuth.Models
{
	public class Account
	{
		public string Id {get; set;}

		[JsonProperty("username")]
		public string Username {get; set;}

		[JsonProperty("email")]
		public string Email {get; set;}

		[JsonProperty("password")]
		public string Password {get; set;}
	}
}
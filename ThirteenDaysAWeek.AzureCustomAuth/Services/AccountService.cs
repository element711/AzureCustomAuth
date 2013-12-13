using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ThirteenDaysAWeek.AzureCustomAuth.Models;
using ThirteenDaysAWeek.AzureCustomAuth.Handlers;
using System.Collections.Generic;
using System;
using ThirteenDaysAWeek.AzureCustomAuth.Factories;

namespace ThirteenDaysAWeek.AzureCustomAuth.Services
{
	public class AccountService
	{
		public static string AuthenticationToken { get; set; }

		public async Task Register(string username, string password, string email)
		{
			await DoInsert(username, password, email, false);
		}

		public async Task<bool> Login(string username, string password)
		{
			bool result;

			try
			{
				await DoInsert(username, password, null, true);
				result = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				result = false;
			}

			return result;
		}

		private async Task DoInsert(string username, string password, string email, bool isLogin)
		{
			Account account = new Account {
				Username = username,
				Password = password,
				Email = email
			};

			using (AuthenticationHandler handler = new AuthenticationHandler()) {
				using (MobileServiceClient client = MobileServiceClientFactory.CreateClient(handler)) {
					var table = client.GetTable<Account>();
					Dictionary<string, string> parameters = new Dictionary<string, string> {
						{ "login", isLogin.ToString().ToLower()}
					};

					await table.InsertAsync(account, parameters);
				}
			}
		}
	}
}


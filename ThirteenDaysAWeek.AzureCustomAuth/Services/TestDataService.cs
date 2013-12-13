using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ThirteenDaysAWeek.AzureCustomAuth.Handlers;
using ThirteenDaysAWeek.AzureCustomAuth.Factories;
using ThirteenDaysAWeek.AzureCustomAuth.Models;
using System;

namespace ThirteenDaysAWeek.AzureCustomAuth.Services
{
	public class TestDataService
	{
		public async Task AddTestData()
		{
			using (var client = MobileServiceClientFactory.CreateClient())
			{
				var data = new TestData {
					DateCreated = DateTime.Now
				};

				var table = client.GetTable<TestData>();

				await table.InsertAsync(data);
			}
		}

		public async Task<TestData> GetMostRecentItem()
		{
			using (var handler = new ZumoAuthHeaderHandler())
			{
				using (var client = MobileServiceClientFactory.CreateClient(handler))
				{
					var table = client.GetTable<TestData>();

					var query = table.Take(1)
						.OrderByDescending(d => d.DateCreated);

					var data = await query.ToListAsync();

					return data.First();
				}
			}
		}
	}
}


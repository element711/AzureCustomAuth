using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;

namespace ThirteenDaysAWeek.AzureCustomAuth.Factories
{
	public static class MobileServiceClientFactory
	{
		public static MobileServiceClient CreateClient()
		{
			return new MobileServiceClient(Preferences.AzureMobileServicesUrl,
				Preferences.AzureMobileServicesKey);
		}

		public static MobileServiceClient CreateClient(params HttpMessageHandler[] handlers)
		{
			return new MobileServiceClient(Preferences.AzureMobileServicesUrl,
				Preferences.AzureMobileServicesKey,
				handlers);
		}
	}
}


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ThirteenDaysAWeek.AzureCustomAuth.Services;
using ThirteenDaysAWeek.AzureCustomAuth.Models;

namespace ThirteenDaysAWeek.AzureCustomAuth.ViewControllers
{
	public partial class HomeViewController : UIViewController
	{
		public HomeViewController() : base ("HomeViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			this.RegisterButton.TouchUpInside += (sender, e) => {
				RegistrationViewController vc = new RegistrationViewController();
				this.PresentViewController(vc, true, null);
			};

			this.LoginButton.TouchUpInside += (sender, e) => {
				LoginViewController vc = new LoginViewController();
				this.PresentViewController(vc, true, null);
			};

			this.GetDataButton.TouchUpInside += async (sender, e) => {
				TestDataService service = new TestDataService();
				await service.AddTestData();

				try
				{
					TestData data = await service.GetMostRecentItem();

					this.BeginInvokeOnMainThread(() => {
						this.StatusLabel.Text = "Data retrieved! Date created was";
						this.DataLabel.Text = data.DateCreated.ToString("G");
					});
				}
				catch (Exception ex)
				{
					this.BeginInvokeOnMainThread(() => {
						this.StatusLabel.TextColor = UIColor.Red;
						this.StatusLabel.Text = ex.Message;
					});
				}
			};
		}
	}
}


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ThirteenDaysAWeek.AzureCustomAuth.Services;

namespace ThirteenDaysAWeek.AzureCustomAuth.ViewControllers
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController() : base ("LoginViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.LoginButton.TouchUpInside += async (object sender, EventArgs e) => {
				AccountService service = new AccountService();
				string username = this.UsernameTextField.Text;
				string password = this.PasswordTextField.Text;

				bool result = await service.Login(username, password);

				if (result)
				{
					this.DismissViewController(true, null);
				}
				else
				{
					this.BeginInvokeOnMainThread(() => {
						this.LoginFailedLabel.Text = "Login failed!";
					});
				}
			};
		}
	}
}


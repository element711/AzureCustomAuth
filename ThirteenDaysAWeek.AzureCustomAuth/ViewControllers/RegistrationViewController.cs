using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ThirteenDaysAWeek.AzureCustomAuth.Services;

namespace ThirteenDaysAWeek.AzureCustomAuth.ViewControllers
{
	public partial class RegistrationViewController : UIViewController
	{
		public RegistrationViewController() : base ("RegistrationViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.RegisterButton.TouchUpInside += async (sender, e) => {
				AccountService service = new AccountService();
				string username = this.UsernameTextField.Text;
				string password = this.PasswordTextField.Text;
				string email = this.EmailAddressTextField.Text;

				await service.Register(username, password, email);

				this.DismissViewController(true, null);
			};
		}
	}
}


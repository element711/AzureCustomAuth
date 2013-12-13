# Getting Started
Before you run this project, you'll need to complete a couple of steps.

1.  If you don't already have a Windows Azure account, you'll need to set one up.  You can either setup a trial account, or if you have an MSDN subscription, you probably have some Azure benefits that you should be taking advantage of.
2.  Create a new Mobile Service in your Azure account. This isn't too complicated but if you need guidance, [MSDN has a good overview of the process][msdnlink].
3.  Create two new tables under your new mobile service, one named Account and one named TestData.  Refere to the previously mentioned [MSDN page][msdnlink] if you're unsure of how to create tables
4.  Go to the Accounts table and create a new script for the Insert operation. Delete the text that's in the editor and paste in the contents of the Scripts/Account.Insert.js file included in this solution
5.  Go to the TestData table and set the following permissions:
	* Insert:  Only Authenticated Users
	* Read:  Only Authenticated Users
6. Open Preferences.cs included in the solution in your preferred text editor or IDE and paste your Mobile Service's URL and Application key into the appropriate property getters.  Your Mobile Service URL and Application Key can be found on the dashboard for your service in the Azure portal

You should now be able to run the app, create new users, login and view protected data once authenticated.


[msdnlink]: http://www.windowsazure.com/en-us/develop/mobile/tutorials/get-started/
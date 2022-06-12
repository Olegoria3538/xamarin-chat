using Plugin.LocalNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OurMessenger2
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());

			ShowNotification();
		}

		private async void ShowNotification()
		{
			var notification = new NotificationRequest
			{
				NotificationId = 100,
				Title = "Test",
				Description = "Test Description",
				ReturningData = "Dummy data", // Returning data when tapped on notification.
				Schedule =
					{
						NotifyTime = DateTime.Now.AddSeconds(30) // Used for Scheduling local notification, if not specified notification will show immediately.
					}
			};
			await NotificationCenter.Current.Show(notification);
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}

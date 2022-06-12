using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OurMessenger2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThirdPage : ContentPage
	{
		public ObservableCollection<UserMessage> Messages;
		public ThirdPage()
		{
			InitializeComponent();

			Messages = new ObservableCollection<UserMessage>();
			Messages.Add(new UserMessage("Bob", "Hello"));
			Messages.Add(new UserMessage("Tom", "Good morning"));
			Messages.Add(new UserMessage("Nelly", "Bye bye"));

			EmulateChat();

			ChatList.ItemsSource = Messages;
		}

		private async void EmulateChat()
		{
			while (true)
			{
				AddMessage("Bob", "Hello");
				await Task.Delay(500);
				AddMessage("Tom", "Good morning");
				await Task.Delay(500);
				AddMessage("Nelly", "Bye bye");
				await Task.Delay(500);
			}
		}

		private void AddMessage(string user, string message)
		{
			var u = new UserMessage(user, message);
			Messages.Add(u);
			ChatList.ScrollTo(u, ScrollToPosition.End, true);
		}
	}

	public class UserMessage
	{
		public string Username { get; private set; }
		public string Message { get; private set; }
		public UserMessage(string user, string message)
		{
			Username = user;
			Message = message;
		}
	}
}
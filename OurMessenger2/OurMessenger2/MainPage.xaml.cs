using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OurMessenger2
{
	public partial class MainPage : ContentPage
	{
		public const string OurTitle = "Месседжер для меня и моего расстройства";
		public bool isLogin = false;
		public string login = "";
		public ChatPage chatPage = null;
		public MainPage()
		{
			
			Title = "Мой awesome месседжер";
			InitializeComponent();
			BtnOpenChat.SetValue(IsVisibleProperty, false);
		}
		private void OpenChat_Pressed(object sender, EventArgs e)
		{
			if (chatPage != null)
			{
				Navigation.PushModalAsync(chatPage);
			}
		}
		private async void Login_Pressed(object sender, EventArgs e)
		{
			var LoginInstace = new Login();
			LoginInstace.Disappearing += (sender2, e2) =>
			{
				isLogin = LoginInstace.isLogin;
				if (LoginInstace.isLogin)
				{
					login = LoginInstace.login;
					UserName.Text = LoginInstace.login;
					StatusUser.Text = "online";
					StatusUser.TextColor = Color.Green;
					BtnLogin.SetValue(IsVisibleProperty, false);
					BtnCreateAccount.SetValue(IsVisibleProperty, false);
					BtnOpenChat.SetValue(IsVisibleProperty, true);
					chatPage = new ChatPage();
					OpenChat_Pressed(sender, e);
				}
            };
			await Navigation.PushModalAsync(LoginInstace);
		}	
		private void CreateAccount_Pressed(object sender, EventArgs e)
		{
			var CreateAccountInstance = new CreateAccount();
			CreateAccountInstance.Disappearing += (sender2, e2) =>
			{
				if(CreateAccountInstance.succes)
                {
					Login_Pressed(sender, e);
				}
			};
			Navigation.PushModalAsync(CreateAccountInstance);
		}
		private async void ButtonLogout_Pressed(object sender, EventArgs e)
		{
			var sheetResult = await DisplayAlert("Выйти?", "Are you sure?", "Да", "Нет");
			if(sheetResult)
            {
				// pass
            }
		}
	}
}

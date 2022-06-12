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
		public MainPage()
		{
			Title = "Мой awesome месседжер";

			InitializeComponent();
		}

		private void ButtonSecond_Pressed(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new SecondPage());
		}
		private void ButtonThird_Pressed(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new ThirdPage());
		}
		private void CreateAccount_Pressed(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new CreateAccount());
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

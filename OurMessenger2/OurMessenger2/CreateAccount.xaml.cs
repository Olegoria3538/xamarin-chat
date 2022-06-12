using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OurMessenger2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private async void CreateAccount_Pressed(object sender, EventArgs e)
        {
            var login = Login.Text;
            var pass = Password.Text;
            var pass2 = Password2.Text;
            if (!(login.Length == 0 || pass.Length == 0 || pass2.Length == 0))
            {
                if(pass != pass2)
                {
                    await DisplayAlert("Пароли не равны", "", "OK");
                } else
                {

                }
            }
        }
    }
}
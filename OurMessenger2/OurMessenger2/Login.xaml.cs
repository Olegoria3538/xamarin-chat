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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void Login_Pressed(object sender, EventArgs e)
        {
            var login = LoginInput.Text;
            var pass = Password.Text;
            if (!(login.Length == 0 || pass.Length == 0))
            {
               // pass
            }
        }
    }
}
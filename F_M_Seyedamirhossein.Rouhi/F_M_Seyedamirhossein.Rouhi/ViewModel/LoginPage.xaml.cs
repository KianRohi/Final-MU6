using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F_M_Seyedamirhossein.Rouhi.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void btnSignup_Clicked(object sender, EventArgs e)
        {
            GoToNextPage(new Signup());
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            if (await Data.Login.Validate(txtUsername.Text, txtPassword.Text))
            {
                GoToNextPage(new User());
            }
        }
        private async void GoToNextPage(Page page)
        {
            txtUsername.Text = txtPassword.Text = "";
            await Navigation.PushAsync(page);
        }
    }
}
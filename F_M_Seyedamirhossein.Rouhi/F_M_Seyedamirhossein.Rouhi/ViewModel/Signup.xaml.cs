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
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }
        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            if (await Data.Signup.Validate(txtUsername.Text, txtPassword.Text))
            {
                GoBackToPreviousPage();
            }
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            GoBackToPreviousPage();
        }

        private async void GoBackToPreviousPage()
        {
            txtUsername.Text = txtPassword.Text = "";
            await Navigation.PopAsync();
        }
    }
}
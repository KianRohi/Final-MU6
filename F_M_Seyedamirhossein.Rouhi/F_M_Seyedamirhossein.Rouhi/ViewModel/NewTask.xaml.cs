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
    public partial class NewTask : ContentPage
    {
        private List<string> pickerSource = new List<string>() { "Low", "Medium", "High", "Critical" };
        public NewTask()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            pickerTaskPriority.ItemsSource = pickerSource;
            pickerTaskPriority.SelectedIndex = 0;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (await Data.Key.AddTask(txtdescription.Text, pickerTaskPriority.SelectedItem.ToString()))
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
            txtdescription.Text = "";
            pickerTaskPriority.SelectedIndex = 0;
            await Navigation.PopAsync();
        }
    }
}
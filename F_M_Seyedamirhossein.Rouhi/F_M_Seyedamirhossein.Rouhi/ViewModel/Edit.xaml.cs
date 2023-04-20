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
    public partial class Edit : ContentPage
    {
        private List<string> pickerSource = new List<string>() { "Low", "Medium", "High", "Critical" };
        Models.Task globakTask;
        public Edit(Models.Task task)
        {
            InitializeComponent();
            globakTask = task;
            Initialize();
        }

        private void Initialize()
        {
            pickerTaskPriority.ItemsSource = pickerSource;
            pickerTaskPriority.SelectedIndex = 0;
            pickerTaskPriority.SelectedIndex = pickerSource.FindIndex(item => item == globakTask.Priority);
        }


        private async void btnEditTask_Clicked(object sender, EventArgs e)
        {
            if (await Data.Key.EditTask(Convert.ToInt32(txtID.Text), txtDescription.Text, pickerTaskPriority.SelectedItem.ToString()))
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
            txtID.Text = txtKey.Text = txtDescription.Text = "";
            await Navigation.PopAsync();
        }
    }
}
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
    public partial class User : ContentPage
    {
        int globalSelectedItemIndex = -1;
        public User()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Initialize();
        }
        private void Initialize()
        {
            list.ItemsSource = null;
            list.ItemsSource = Data.Key.GetAllTasks();
            list.SelectedItem = null;
            SetButtonsEnablement(false);
        }
        private void SetButtonsEnablement(bool state)
        {
            btnEdit.IsEnabled = btnDelete.IsEnabled = state;
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItemIndex >= 0)
            {
                globalSelectedItemIndex = e.SelectedItemIndex;
                SetButtonsEnablement(true);
            }
            else
            {
                SetButtonsEnablement(false);

            }
        }

        private  async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTask());
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            Models.Task task = (Models.Task)list.SelectedItem;
            var taskDetail = new Edit(task);
            taskDetail.BindingContext = task;
            SetButtonsEnablement(false);
            await Navigation.PushAsync(taskDetail);
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            Models.Task task = (Models.Task)list.SelectedItem;
            bool respond = await DisplayAlert("Alert", "Are you sure you want to delete the Task " + task.ID + " ?", "Yes", "No");
            if (respond)
            {
                if (await Data.Key.DeleteTask(task.ID))
                {
                    SetButtonsEnablement(false);
                }
            }
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
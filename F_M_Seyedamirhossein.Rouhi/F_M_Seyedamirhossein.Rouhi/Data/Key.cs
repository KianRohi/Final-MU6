using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace F_M_Seyedamirhossein.Rouhi.Data
{
    class Key
    {
        private static int serverID; 
        static public ObservableCollection<Models.Task> GetAllTasks()
        {
            serverID = 0;
            FirebaseData.allTasks.Clear();
            var collection = FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).AsObservable<Models.Task>().Subscribe(item =>
            {
                if (item.Object != null) 
                {
                    FirebaseData.allTasks.Add(new Models.Task() { ID = item.Object.ID, Key = item.Key, Description = item.Object.Description, Priority = item.Object.Priority });
                    serverID++;
                }
            });
            return FirebaseData.allTasks;
        }

        static public async Task<bool> AddTask(string taskDescription, string taskPriority)
        {
            if (!String.IsNullOrEmpty(taskDescription))
            {
                if (!String.IsNullOrEmpty(taskPriority))
                {
                    try
                    {
                        await FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).PostAsync(new Models.Task() { ID = serverID + 1, Description = taskDescription, Priority = taskPriority });
                        await App.Current.MainPage.DisplayAlert("Alert", "Created successfully, Thank you", "Ok");
                        return true;
                    }
                    catch
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Error, try again", "Ok");
                        return false;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "The field of priority cannot be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "The field of description cannot be empty", "Ok");
                return false;
            }
        }

        private static object GetFirebaseClient()
        {
            throw new NotImplementedException();
        }

        static public async Task<bool> DeleteTask(int taskID)
        {
            var taskToDelete = (await FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).OnceAsync<Models.Task>()).Where(item => item.Object.ID == taskID).FirstOrDefault();
            if (taskToDelete != null)
            {
                try
                {
                    await FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).Child(taskToDelete.Key).DeleteAsync();
                    GetAllTasks();
                    await App.Current.MainPage.DisplayAlert("Alert", "Deleted successfully!", "Ok");
                    return true;
                }
                catch
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Error, try again", "Ok");
                    return false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Error, try again", "Ok");
                return false;
            }
        }

        static public async Task<bool> EditTask(int taskID, string taskDescription, string taskPriority)
        {
            var taskToUpdate = (await FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).OnceAsync<Models.Task>()).Where(item => item.Object.ID == taskID).FirstOrDefault();
            if (taskToUpdate != null)
            {
                if (!String.IsNullOrEmpty(taskDescription))
                {
                    if (!String.IsNullOrEmpty(taskPriority))
                    {
                        try
                        {
                            await FirebaseData.GetFirebaseClient().Child(FirebaseData.GetTasksTableName()).Child(taskToUpdate.Key).PutAsync(new Models.Task() { ID = taskID, Description = taskDescription, Priority = taskPriority });
                            GetAllTasks();
                            await App.Current.MainPage.DisplayAlert("Alert", "Edited successfully!", "Ok");
                            return true;
                        }
                        catch
                        {
                            await App.Current.MainPage.DisplayAlert("Alert", "Error, try again", "Ok");
                            return false;
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "The field priority cannot be empty", "Ok");
                        return false;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "The field of description  cannot be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Error, try again", "Ok");
                return false;
            }
        }
    }
}

using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace F_M_Seyedamirhossein.Rouhi.Data
{
    internal class FirebaseData
    {
        private static string apiKey = "AIzaSyB5ZbJUebSuujLXRbX24_DakMapX-rWBz4";
        private static FirebaseClient firebaseClient = new FirebaseClient("https://finalexam-2809a-default-rtdb.firebaseio.com/");
        public static ObservableCollection<Models.Task> allTasks = new ObservableCollection<Models.Task>();
        private static string tasksTableName = "Tasks";

        public static string GetAPIKey()
        {
            return apiKey;
        }

        public static FirebaseClient GetFirebaseClient()
        {
            return firebaseClient;
        }

        public static string GetTasksTableName()
        {
            return tasksTableName;
        }
    }
}

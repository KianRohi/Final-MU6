using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace F_M_Seyedamirhossein.Rouhi.Data
{
   internal class Signup
    {
        static public async Task<bool> Validate(string username, string password)
        {
            if (!String.IsNullOrEmpty(username))
            {
                if (!String.IsNullOrEmpty(password))
                {
                    try
                    {

                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseData.GetAPIKey()));
                        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(username, password);
                        await App.Current.MainPage.DisplayAlert("Alert", "User " + username + " Created!", "OK");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        FirebaseAuthException error = ex as FirebaseAuthException;
                        await App.Current.MainPage.DisplayAlert("Alert", error.Reason.ToString(), "Ok");
                        return false;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "The field cannot be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "The fields cannot be empty", "Ok");
                return false;
            }
        }
    }
}

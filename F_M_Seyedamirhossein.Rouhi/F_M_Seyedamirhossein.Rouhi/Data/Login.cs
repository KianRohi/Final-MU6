using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace F_M_Seyedamirhossein.Rouhi.Data
{
    internal class Login
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
                        var auth = await authProvider.SignInWithEmailAndPasswordAsync(username, password);
                        await App.Current.MainPage.DisplayAlert("Alert", "The Login" + username + "successful, Thank you", "OK");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        FirebaseAuthException error = ex as FirebaseAuthException;
                        await App.Current.MainPage.DisplayAlert("Alert", error.Reason.ToString(), "OK");
                        return false;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "The field can not be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "The fields can not be empty", "Ok");
                return false;
            }
        }
    
    }
}

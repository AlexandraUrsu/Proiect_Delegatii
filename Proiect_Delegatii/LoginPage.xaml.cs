using Proiect_Delegatii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiect_Delegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        static string passwordEncryption(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)

            {

                sBuilder.Append(data[i].ToString("x2"));

            }
            return sBuilder.ToString();

        }


        void SignInEvent(object sender, EventArgs e)
        {
            User user = new User(entry_username.Text, entry_pass.Text);
           
            if (user.Username==null|| user.Parola==null || user.Username.Equals("") || user.Parola.Equals(""))
            {
                DisplayAlert("Login", "Introduceti un user si o parola", "Ok");
            }
            else
            { 
                user.Parola = passwordEncryption(user.Parola);
                 Task<User> taskUser = App.Database.GetUserAsync(user.Username);
                 User userr = taskUser.Result;
                 if (userr == null)
                 {
                     DisplayAlert("Login", "User invalid", "Ok");
                 }
                 else
                 {
                     Task<User> taskUserPariola = App.Database.GetParolaAsync(user.Username);
                     User user_p = taskUserPariola.Result;
                     if (!user_p.Parola.Equals(user.Parola))
                         DisplayAlert("Login", "Parola invalida", "Ok");
                     else
                     {
                         Task<User> taskUserRol = App.Database.GetRolAsync(user.Username);
                         User user_r = taskUserRol.Result;
                         if (user_r.Rol.Equals("administrator"))
                         {
                             DisplayAlert(userr.Username, "Administrator", "Ok");
                            Application.Current.MainPage = new NewAppShell();
                           // ((AppShell)App.Current.MainPage).CurrentItem.CurrentItem.Navigation.PushAsync(new AdminPage());
                        }
                         else if (user_r.Rol.Equals("user"))
                         {
                            DisplayAlert(user.Username, "User", "Ok");
                            App.Current.MainPage = new AppShell(user);
                        }
                    }
                }
               
            }
        }

        
    }

}
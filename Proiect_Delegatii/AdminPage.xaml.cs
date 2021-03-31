using Proiect_Delegatii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiect_Delegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTotiUseriiAsync();
        }

        async void OnUserAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAdaugare()
            {
                BindingContext = new User()

            });
        }

        private async void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            User u;
            if (e.SelectedItem != null)
            {
                u = e.SelectedItem as User;
                var actionSheet = await DisplayActionSheet(u.Username, "Cancel", null, "Stergere", "Modificare");

                switch (actionSheet)
                {
                    case "Cancel":

                        // Do Something when 'Cancel' Button is pressed

                        break;

                    case "Stergere":

                        await App.Database.DeleteUserAsync(u);

                        Navigation.PushAsync(new AdminPage());
                        Navigation.PopAsync();


                        break;

                    case "Modificare":
                        u.id = 1;
                        await Navigation.PushAsync(new UserAdaugare()
                        {
                            BindingContext = e.SelectedItem as User
                        });

                        break;

                }
            }
        }
    }
}
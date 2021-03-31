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
    public partial class AppShell : Xamarin.Forms.Shell
    {
        User u;
        public AppShell(User user)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(DelegatiiEntryPage), typeof(DelegatiiEntryPage));
            Routing.RegisterRoute(nameof(ContulMeu), typeof(ContulMeu));
            u=user;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnContulMeuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContulMeu(u));
        }
    }
}
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
    public partial class ListDelegatie : ContentPage
    {
        public ListDelegatie()
        {
            InitializeComponent();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiCompanie((Delegatie)
           this.BindingContext)
            {
                BindingContext = new Angajat()
            });

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Delegatie)BindingContext;
            slist.Data = DateTime.UtcNow;
            await App.Database.SaveDelegatieAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Delegatie)BindingContext;
            await App.Database.DeleteDelegatieAsync(slist);
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var del = (Delegatie)BindingContext;

            listView.ItemsSource = await App.Database.GetListAngajatiAsync(del.ID);
        }
        private async void OnSelect(object sender, SelectedItemChangedEventArgs e)
        {
            Angajat a;
            var del = (Delegatie)BindingContext;
            if (e.SelectedItem != null)
            {
                a = e.SelectedItem as Angajat;
                var actionSheet = await DisplayActionSheet(a.Nume + " " + a.Prenume, "Cancel", null, "Stergere");

                switch (actionSheet)
                {
                    case "Cancel":

                        // Do Something when 'Cancel' Button is pressed

                        break;

                    case "Stergere":
                        Task<ListAngajat> taskListAngajat = App.Database.GetListAngajatAsync(del.ID, a.ID);
                        ListAngajat listang = taskListAngajat.Result;
                        await App.Database.DeleteListAngajatAsync(listang);
                        if (listang != null)
                            DisplayAlert("Sters cu succes", "Angajatul "+a.Nume+" "+a.Prenume+" a fost strers din delegatia "+del.ID, "Ok");
                        else DisplayAlert("Failed", "Sregerea nu se poate realiza", "Ok");
                        Navigation.PopAsync();
                        break;
                }
            }
        }
    }
}
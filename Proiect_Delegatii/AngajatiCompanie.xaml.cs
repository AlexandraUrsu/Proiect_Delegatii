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
    public partial class AngajatiCompanie : ContentPage
    {
        Delegatie dl;

        public AngajatiCompanie(Delegatie del)
        {
            InitializeComponent();
            dl = del;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            await App.Database.SaveAngajatAsync(angajat);
            listView.ItemsSource = await App.Database.GetAngajatiAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            await App.Database.DeleteAngajatAsync(angajat);
            listView.ItemsSource = await App.Database.GetAngajatiAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAngajatiAsync();
            
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Angajat a;
            if (e.SelectedItem != null)
            {
                a = e.SelectedItem as Angajat;
                var la = new ListAngajat()
                {
                    DelegatieID = dl.ID,
                    AngajatID = a.ID
                };
                await App.Database.SaveListAngajatAsync(la);
                a.ListAngajati = new List<ListAngajat> { la };

                await Navigation.PopAsync();
            }
        }
    }
}
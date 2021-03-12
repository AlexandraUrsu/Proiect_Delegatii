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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAngajatAsync();
        }

        async void OnAngajatAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiAdaugare(dl)
            {
                BindingContext = new Angajat()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AngajatiAdaugare(dl)
                {
                    BindingContext = e.SelectedItem as Angajat
                });
            }
        }
    }
}
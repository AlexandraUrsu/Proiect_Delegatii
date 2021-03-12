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
    public partial class AngajatiAdaugare : ContentPage
    {
        Delegatie dl;

        public AngajatiAdaugare(Delegatie del)
        {
            InitializeComponent();
            dl = del;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            await App.Database.SaveAngajatAsync(angajat);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            await App.Database.DeleteAngajatAsync(angajat);
            await Navigation.PopAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }

    }
}
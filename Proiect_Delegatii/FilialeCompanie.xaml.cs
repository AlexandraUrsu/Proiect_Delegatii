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
    public partial class FilialeCompanie : ContentPage
    {
        Angajat an;
        public FilialeCompanie(Angajat ang)
        {
            InitializeComponent();
            an = ang;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var filiala = (Filiala)BindingContext;
            await App.Database.SaveFilialaAsync(filiala);
            listView.ItemsSource = await App.Database.GetFilialaAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var filiala = (Filiala)BindingContext;
            await App.Database.DeleteFilialaAsync(filiala);
            listView.ItemsSource = await App.Database.GetFilialaAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetFilialaAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Filiala f;
            if (e.SelectedItem != null)
            {
                f = e.SelectedItem as Filiala;
                var lf = new ListFiliala()
                {
                    AngajatID = an.ID,
                    FilialaID = f.ID
                };
                await App.Database.SaveListFilialaAsync(lf);
                f.ListFiliala = new List<ListFiliala> { lf };

                await Navigation.PopAsync();
            }
        }
    }
}
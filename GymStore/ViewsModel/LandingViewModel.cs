using GymStore.Model;
using GymStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymStore.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            supplements = GetSupplements();
        }

        ObservableCollection<Supplement> supplements;
        public ObservableCollection<Supplement> Supplements
        {
            get { return supplements; }
            set
            {
                supplements = value;
                OnPropertyChanged();
            }
        }

        private Supplement selectedSupplement;
        public Supplement SelectedSupplement
        {
            get { return selectedSupplement; }
            set
            {
                selectedSupplement = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplaySupplement);

        private void DisplaySupplement()
        {
            if (selectedSupplement != null)
            {
                var viewModel = new DetailsViewModel { SelectedSupplement = selectedSupplement, Supplements = supplements, Position = supplements.IndexOf(selectedSupplement) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Supplement> GetSupplements()
        {
            return new ObservableCollection<Supplement>
            {
                new Supplement { Name = "PROTEINA", Price = 129.99f, Image = "proteina.png", Description = "Produsul conține o proporție mare de proteine, BCAA, solubilitate excelentă, absorbție și gust plăcut. Este un produs de origine slovacă care se caracterizează printr-un profil excelent de aminoacizi, conține 8% leucină - cel mai eficient aminoacid BCAA și cu efecte anabolice puternice."},
                new Supplement { Name = "PREWORKOUT", Price = 69.99f, Image = "preworkout.png", Description = "Stimulentul de pre-antrenament Thor Fuel + Vitargo este noua formulă extrem de puternică a stimulentului de pre-antrenament Thor cu adaos de Vitargo® - un carbohidrat patentat, o sursă excelentă de energie rapidă pentru creșterea performanței și suplimentarea depozitelor de glicogen."},
                new Supplement { Name = "CREATINA", Price = 49.29f, Image = "creatina.png", Description = "Creatine este un supliment pe bază de creatină care crește pe deplin și în mod eficient puterea și permite un antrenament mult mai lung și mai intens, ceea ce ajută la construirea musculaturii pure. Este potrivit pentru sportivii cu experiență dar și pentru cei începători. Creatina, de asemenea, ajută la construirea musculaturii pure, a volumului său și a hidratării celulelor musculare."},
                new Supplement { Name = "CARNITINA", Price = 23.99f, Image = "carnitina.png", Description = "L-Carnitina este cel mai eficient arzător natural de grăsimi sub formă lichidă. Datorită conținutului ridicat de substanță naturală l-carnitină, asigură arderea rapidă și eficientă a grăsimilor. În plus, acest produs este îmbogățit cu vitaminele C, B6, B5 și fier care ajută la reducerea oboselii și promovează performanța. "},
                new Supplement { Name = "BCAA", Price = 39.99f, Image = "BCAA.png", Description = "BCAA 1000 sunt aminoacizi de înaltă calitate cu un lanţ ramificat de L-leucină, L-valină şi L-izoleucină, într-un raport optim de  2:1:1 şi o compoziţie excelentă de până la 1000 mg de BCAA. Sunt destinaţi fiecărui sprotiv sau sportivă pentru regenerarea şi protejarea masei musculare."},
                new Supplement { Name = "VITAMINE", Price = 19.99f, Image = "multivitamine.png", Description = "Multivitaminele Vitality complex conține minerale, vitamine și antioxidanți, într-o doză care acoperă nevoile nutritive zilnice ale fiecărui sportiv. Complexul constă în doza optimă de vitamine C, E și vitaminele din grupa B. În plus, conține și alte ingrediente active, cum ar fi ginkgo biloba sau minerale, precum zinc, siliciu, crom, fier și magneziu."}
            };
        }
    }
}

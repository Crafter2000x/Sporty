using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sporty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        public WorkoutsPage()
        {
            InitializeComponent();
        }

        private void btnBereken_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (SliderKeuze.Value.Equals(0))
                {
                    Bereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6);
                    AlternatiefBereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 8, 6.4, "rennen", "fietsen");
                }
                else if (SliderKeuze.Value.Equals(1))
                {
                    Bereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 8);
                    AlternatiefBereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6, 6.4, "lopen", "fietsen");
                }
                else if (SliderKeuze.Value.Equals(2))
                {
                    Bereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 6.4);
                    AlternatiefBereken(Convert.ToInt32(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6, 8, "lopen", "rennen");
                }
            } catch { }
        }

        void Bereken(int Tijd, double Gewicht, double METWaarde)
        {
            double uitkomst;

            uitkomst = Tijd * Gewicht * 0.0175 * METWaarde;
            lblUitkomst.Text = "Aantal calorieen verbrand: " + Convert.ToInt32(uitkomst) + " kcal";
        }

        void AlternatiefBereken(int Tijd, double Gewicht, double METWaarde1, double METWaarde2, string Keuze1, string Keuze2)
        {
            double uitkomst1;
            double uitkomst2;

            uitkomst1 = Tijd * Gewicht * 0.0175 * METWaarde1;
            uitkomst2 = Tijd * Gewicht * 0.0175 * METWaarde2;

            lblAlternatief1.Text = "   Bij " + Keuze1 + " had U " + Convert.ToInt32(uitkomst1) + " kcal verbrand.";
            lblAlternatief2.Text = "   Bij " + Keuze2 + " had U " + Convert.ToInt32(uitkomst2) + " kcal verbrand.";
        }

        private void btnLopen_Clicked(object sender, EventArgs e)
        {
            imgKeuze.Source = "Lopen.png";
            SliderKeuze.Value = 0;
            btnLopen.BackgroundColor = Color.Beige;
            btnRennen.BackgroundColor = Color.WhiteSmoke;
            btnFietsen.BackgroundColor = Color.WhiteSmoke;
        }

        private void btnRennen_Clicked(object sender, EventArgs e)
        {
            imgKeuze.Source = "Rennen.png";
            SliderKeuze.Value = 1;
            btnRennen.BackgroundColor = Color.Beige;
            btnLopen.BackgroundColor = Color.WhiteSmoke;
            btnFietsen.BackgroundColor = Color.WhiteSmoke;
        }

        private void btnFietsen_Clicked(object sender, EventArgs e)
        {
            imgKeuze.Source = "Fietsen.png";
            SliderKeuze.Value = 2;
            btnFietsen.BackgroundColor = Color.Beige;
            btnRennen.BackgroundColor = Color.WhiteSmoke;
            btnLopen.BackgroundColor = Color.WhiteSmoke;
        }
    }
}
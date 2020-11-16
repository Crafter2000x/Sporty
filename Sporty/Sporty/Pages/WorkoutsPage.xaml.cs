using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Sporty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        Stopwatch stopwatch;
        public WorkoutsPage()
        {
            InitializeComponent();
            DisplayCurLoc();
            stopwatch = new Stopwatch();
        }

        public async void DisplayCurLoc()
        {
            try
            {
                var requestStart = new GeolocationRequest(GeolocationAccuracy.High);
                var locationBegin = await Geolocation.GetLocationAsync(requestStart);

                if (locationBegin != null)
                {
                    Position Begin = new Position(locationBegin.Latitude, locationBegin.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(Begin, Distance.FromMeters(.444));
                    map.MoveToRegion(mapSpan);
                }
            }

            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        string tijd;

        private void btnStarten_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(60), () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                        lblStopwatch.Text = stopwatch.Elapsed.ToString()); // lblStopwatch.Text mogelijk veranderen door tijd
                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }

        private void btnPauzeren_Clicked(object sender, EventArgs e)
        {
            btnStarten.Text = "Verder";
            stopwatch.Stop();
        }

        public void btnStoppen_Clicked(object sender, EventArgs e)
        {
            double tijd = stopwatch.Elapsed.TotalMinutes;
            tijd = Math.Round(tijd, 1);
            txtTijd.Text = Convert.ToString(tijd);
            stopwatch.Stop();
            btnStarten.Text = "Starten";
            lblStopwatch.Text = "00:00:00";
        }

        private void btnBereken_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (SliderKeuze.Value.Equals(0))
                {
                    Bereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6);
                    AlternatiefBereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 8, 6.4, "rennen", "fietsen");
                }
                else if (SliderKeuze.Value.Equals(1))
                {
                    Bereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 8);
                    AlternatiefBereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6, 6.4, "lopen", "fietsen");
                }
                else if (SliderKeuze.Value.Equals(2))
                {
                    Bereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 6.4);
                    AlternatiefBereken(Convert.ToDouble(txtTijd.Text), Convert.ToDouble(txtGewicht.Text), 3.6, 8, "lopen", "rennen");
                }
            }
            catch { }
            stopwatch.Reset();
        }

        void Bereken(double Tijd, double Gewicht, double METWaarde)
        {
            double uitkomst;

            uitkomst = Tijd * Gewicht * 0.0175 * METWaarde;
            lblUitkomst.Text = "Aantal calorieen verbrand: " + Convert.ToInt32(uitkomst) + " kcal";
        }

        void AlternatiefBereken(double Tijd, double Gewicht, double METWaarde1, double METWaarde2, string Keuze1, string Keuze2)
        {
            double uitkomst1;
            double uitkomst2;

            uitkomst1 = Tijd * Gewicht * 0.0175 * METWaarde1;
            uitkomst2 = Tijd * Gewicht * 0.0175 * METWaarde2;

            lblAlternatief1.Text = " Bij " + Keuze1 + " had U " + Convert.ToInt32(uitkomst1) + " kcal verbrand.";
            lblAlternatief2.Text = " Bij " + Keuze2 + " had U " + Convert.ToInt32(uitkomst2) + " kcal verbrand.";
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

        private void btnTerug_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void btnOpties_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.OptiesPage());
        }
    }
}

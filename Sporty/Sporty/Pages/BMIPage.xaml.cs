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
    public partial class BMIPage : ContentPage
    {
        public BMIPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                double Gewicht = Convert.ToDouble(editgewicht.Text);
                double lengte = Convert.ToDouble(editlengte.Text) / 100;
                double lengtekwadraat = lengte * lengte;

                double uitkomst = Gewicht / lengtekwadraat;

                if (uitkomst < 18.5)
                {
                    if (uitkomst == 0)
                    {
                        txtBMI.TextColor = Color.Black;
                    }
                    else
                    {
                        txtBMI.TextColor = Color.Orange;
                    }

                }
                else if (uitkomst >= 18.5 && uitkomst < 24.5)
                {
                    txtBMI.TextColor = Color.LimeGreen;
                }
                else if (uitkomst >= 24.5)
                {
                    txtBMI.TextColor = Color.Red;
                }
                uitkomst = Math.Round(uitkomst, 1);
                txtBMI.Text = "Jouw BMI-waarde: " + uitkomst.ToString();
            }
            catch
            {
                txtBMI.Text = "Jouw BMI-waarde: 0";
            }

        }
    }
}

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
            double Gewicht = Convert.ToDouble(editgewicht.Text);
            double lengte = Convert.ToDouble(editlengte.Text) / 100;
            double lengtekwadraat = lengte * lengte;

            double uitkomst = Gewicht / lengtekwadraat;


            txtBMI.Text = uitkomst.ToString();


        }
    }
}
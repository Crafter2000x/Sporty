using Sporty.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sporty
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Navigation(object sender, EventArgs e)
        {
            var button = (Button)sender;

            switch (button.ClassId) 
            {
                case "Overzichten":
                    Navigation.PushAsync(new OverzichtenPage());
                    return;

                case "Workouts":
                    Navigation.PushAsync(new WorkoutsPage());
                    return;

                case "BMI":
                    Navigation.PushAsync(new BMIPage());
                    return;

                case "Routes":
                    Navigation.PushAsync(new RoutesPage());
                    return;

                case "Data":
                    Navigation.PushAsync(new DataOverPage());
                    return;

                case "Opties":
                    Navigation.PushAsync(new OptiesPage());
                    return;
            }
        }

    }
}

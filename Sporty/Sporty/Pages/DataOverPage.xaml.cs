using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sporty.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataOverPage : ContentPage
    {
        bool truefalse = true;

        public DataOverPage()
        {
            InitializeComponent();
        }

        private void EnableDataTransport(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;

            

            if (truefalse == true)
            {
                button.Source = "power_button_on.png";
                truefalse = false;
            }
            else if (truefalse == false)
            {
                button.Source = "power_button_off.png";
                truefalse = true;

            }
 

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
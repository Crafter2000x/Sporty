using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Sporty.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesPage : ContentPage
    {
        public RoutesPage()
        {
            InitializeComponent();
            DisplayCurLoc();

        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            if (switchy.IsToggled)
            {
                loop.IsVisible = true;
                fiets.IsVisible = false;
                fietsplaatje.IsVisible = false;
                fietsplaatje2.IsVisible = false;
                voetgangerplaatje.IsVisible = true;
                voetgangerplaatje2.IsVisible = true;
            }
            else
            {
                fietsplaatje.IsVisible = true;
                fietsplaatje2.IsVisible = true;
                voetgangerplaatje.IsVisible = false;
                voetgangerplaatje2.IsVisible = false;
                loop.IsVisible = false;
                fiets.IsVisible = true;

            }


        }
        public async void DisplayCurLoc()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);


                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    mapslocal.MoveToRegion(mapSpan);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Feature not supported on device
            }
            catch (Exception)
            {
                // Handle exception that may have occurred in geocoding

            }

        }
        private bool button1LoopWasClicked = false;


        private bool button1FietsWasClicked = false;

        private void Button_Clicked(object sender, EventArgs e)
        {
            mapslocal.MapElements.Clear();
            mapslocal.Pins.Clear();

            if (button1LoopWasClicked)
            {
                var pin = new Pin()
                {
                    Position = new Position(51.443460, 5.479497),
                    Label = "Startpunt wandelroute"
                };
                mapslocal.Pins.Add(pin);
                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.Black,
                    StrokeWidth = 12,
                    Geopath =
                    {

                        new Position(51.441744, 5.480420),
                        new Position(51.442397, 5.485501),
                        new Position(51.442520, 5.486790),
                        new Position(51.443041, 5.490637),
                        new Position(51.443348, 5.492730),
                        new Position(51.444000, 5.498094),
                        new Position(51.444166, 5.500537),
                        new Position(51.444407, 5.502517),
                        new Position(51.444407, 5.503738),
                        new Position(51.444037, 5.505481),
                        new Position(51.444800, 5.506280),
                        new Position(51.445309, 5.508098),
                        new Position(51.445381, 5.508245),
                        new Position(51.446132, 5.514286),
                        new Position(51.446105, 5.514612),
                        new Position(51.446653, 5.515307),
                        new Position(51.448140, 5.517719),
                        new Position(51.448411, 5.517878),
                        new Position(51.449190, 5.517527),
                        new Position(51.449790, 5.515741),
                        new Position(51.450037, 5.514739),
                        new Position(51.450383, 5.513585),
                        new Position(51.450931, 5.512953),
                        new Position(51.453623, 5.510771),
                        new Position(51.454104, 5.512066),
                        new Position(51.454491, 5.511735),
                        new Position(51.455157, 5.511770),
                        new Position(51.455610, 5.513113),
                        new Position(51.455616, 5.513007),
                        new Position(51.456103, 5.512621),
                        new Position(51.456325, 5.513330),
                        new Position(51.457390, 5.512394),
                        new Position(51.457791, 5.513763),
                        new Position(51.459050, 5.513433),
                        new Position(51.459413, 5.513379),
                        new Position(51.460562, 5.513081),
                        new Position(51.460798, 5.513026),
                        new Position(51.460797, 5.512637),
                        new Position(51.460667, 5.511610),
                        new Position(51.460495, 5.510940),
                        new Position(51.459958, 5.509380),
                        new Position(51.459431, 5.508056),
                        new Position(51.458683, 5.507016),
                        new Position(51.457719, 5.505415),
                        new Position(51.457670, 5.505275),
                        new Position(51.457651, 5.505106),
                        new Position(51.457726, 5.504418),
                        new Position(51.457612, 5.504345),
                        new Position(51.457746, 5.502937),
                        new Position(51.457768, 5.501578),
                        new Position(51.457751, 5.501495),
                        new Position(51.457746, 5.499989),
                        new Position(51.457385, 5.499921),
                        new Position(51.456602, 5.499541),
                        new Position(51.455834, 5.498940),
                        new Position(51.455682, 5.498992),
                        new Position(51.454667, 5.498348),
                        new Position(51.453912, 5.498546),
                        new Position(51.453796, 5.498699),
                        new Position(51.453717, 5.498339),
                        new Position(51.453480, 5.498173),
                        new Position(51.453035, 5.497736),
                        new Position(51.452329, 5.496514),
                        new Position(51.451725, 5.495711),
                        new Position(51.452089, 5.494687),
                        new Position(51.452401, 5.493270),
                        new Position(51.452565, 5.492394),
                        new Position(51.452746, 5.489619),
                        new Position(51.452623, 5.489582),
                        new Position(51.452567, 5.489466),
                        new Position(51.452540, 5.489339),
                        new Position(51.452400, 5.489312),
                        new Position(51.452389, 5.488519),
                        new Position(51.452260, 5.488482),
                        new Position(51.451955, 5.488481),
                        new Position(51.451864, 5.488436),
                        new Position(51.451795, 5.488189),
                        new Position(51.451765, 5.488159),
                        new Position(51.451454, 5.488154),
                        new Position(51.451289, 5.488255),
                        new Position(51.451016, 5.487554),
                        new Position(51.450728, 5.487080),
                        new Position(51.450524, 5.486871),
                        new Position(51.450220, 5.487076),
                        new Position(51.449827, 5.485831),
                        new Position(51.449245, 5.484870),
                        new Position(51.448286, 5.483508),
                        new Position(51.448195, 5.483464),
                        new Position(51.448453, 5.482927),
                        new Position(51.447609, 5.482316),
                        new Position(51.447016, 5.482240),
                        new Position(51.446341, 5.482528),
                        new Position(51.446063, 5.482623),
                        new Position(51.445653, 5.482542),
                        new Position(51.445574, 5.482005),
                        new Position(51.445214, 5.481216),
                        new Position(51.445133, 5.481017),
                        new Position(51.444683, 5.481130),
                        new Position(51.444373, 5.480805),
                        new Position(51.443600, 5.479290),
                        new Position(51.443460, 5.479497)


                    }
                };

                mapslocal.MapElements.Add(polyline);

                button1LoopWasClicked = false;
            }

            if (button1FietsWasClicked)
            {
                var pin = new Pin()
                {
                    Position = new Position(51.441744, 5.480420),
                    Label = "Startpunt fietsroute"
                };
                mapslocal.Pins.Add(pin);
                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.Black,
                    StrokeWidth = 12,
                    Geopath =
                        {

                        new Position(51.441744, 5.480420),
                        new Position(51.441512, 5.478584),
                        new Position(51.441655, 5.478194),
                        new Position(51.441510, 5.477865),
                        new Position(51.441321, 5.476004),
                        new Position(51.441238, 5.475871),
                        new Position(51.441145, 5.475647),
                        new Position(51.440786, 5.475664),
                        new Position(51.439000, 5.474727),
                        new Position(51.438695, 5.474723),
                        new Position(51.438695, 5.474719),
                        new Position(51.438413, 5.474911),
                        new Position(51.438107, 5.475762),
                        new Position(51.437327, 5.477080),
                        new Position(51.435451, 5.479486),
                        new Position(51.434337, 5.480611),
                        new Position(51.433834, 5.480123),
                        new Position(51.433372, 5.479411),
                        new Position(51.433502, 5.479075),
                        new Position(51.434244, 5.478402),
                        new Position(51.433781, 5.478936),
                        new Position(51.435548, 5.478247),
                        new Position(51.436299, 5.477440),
                        new Position(51.436094, 5.476995),
                        new Position(51.435492, 5.474565),
                        new Position(51.435417, 5.473591),
                        new Position(51.435285, 5.473287),
                        new Position(51.435449, 5.472910),
                        new Position(51.435505, 5.472275),
                        new Position(51.435497, 5.471875),
                        new Position(51.434710, 5.469581),
                        new Position(51.434122, 5.468547),
                        new Position(51.434072, 5.468344),
                        new Position(51.433463, 5.466792),
                        new Position(51.433463, 5.466792),
                        new Position(51.435240, 5.464134),
                        new Position(51.435796, 5.462282),
                        new Position(51.436010, 5.461872),
                        new Position(51.437162, 5.463811),
                        new Position(51.437448, 5.464192),
                        new Position(51.437814, 5.464393),
                        new Position(51.438077, 5.464498),
                        new Position(51.438457, 5.464900),
                        new Position(51.438789, 5.465448),
                        new Position(51.438943, 5.465457),
                        new Position(51.439269, 5.463464),
                        new Position(51.439584, 5.463581),
                        new Position(51.439714, 5.463243),
                        new Position(51.440264, 5.462640),
                        new Position(51.440379, 5.462486),
                        new Position(51.440343, 5.462043),
                        new Position(51.442230, 5.461064),
                        new Position(51.442329, 5.461211),
                        new Position(51.443499, 5.461226),
                        new Position(51.443676, 5.461001),
                        new Position(51.443677, 5.460637),
                        new Position(51.444587, 5.457879),
                        new Position(51.446573, 5.459680),
                        new Position(51.445525, 5.461242),
                        new Position(51.445037, 5.462331),
                        new Position(51.444403, 5.464121),
                        new Position(51.443522, 5.465475),
                        new Position(51.442964, 5.466613),
                        new Position(51.442444, 5.467917),
                        new Position(51.441620, 5.469721),
                        new Position(51.442669, 5.471052),
                        new Position(51.442808, 5.471755),
                        new Position(51.442874, 5.472392),
                        new Position(51.442921, 5.472555),
                        new Position(51.442945, 5.472798),
                        new Position(51.443047, 5.473188),
                        new Position(51.443373, 5.474804),
                        new Position(51.443718, 5.476762),
                        new Position(51.443867, 5.477652),
                        new Position(51.443780, 5.477677),
                        new Position(51.443543, 5.477655),
                        new Position(51.443462, 5.478222),
                        new Position(51.443460, 5.478366),
                        new Position(51.443585, 5.479256),
                        new Position(51.443452, 5.479508)
                        }
                };
                mapslocal.MapElements.Add(polyline);
                button1FietsWasClicked = false;
            }

        }

        private void route1_Clicked(object sender, EventArgs e)
        {
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            button1FietsWasClicked = false;
            button1LoopWasClicked = true;
            route1.BackgroundColor = Color.Beige;
        }

        private void fietsroute1_Clicked(object sender, EventArgs e)
        {
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            button1LoopWasClicked = false;
            button1FietsWasClicked = true;
            fietsroute1.BackgroundColor = Color.Beige;

        }

        private void route2_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.Beige;
        }

        private void route3_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.Beige;
        }

        private void route4_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.Beige;
        }

        private void route5_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.Beige;
        }

        private void fietsroute2_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.Beige;
        }

        private void fietsroute3_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.Beige;
        }

        private void fietsroute4_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.Beige;
        }

        private void fietsroute5_Clicked(object sender, EventArgs e)
        {
            button1LoopWasClicked = false;
            button1FietsWasClicked = false;
            route1.BackgroundColor = Color.WhiteSmoke;
            route2.BackgroundColor = Color.WhiteSmoke;
            route3.BackgroundColor = Color.WhiteSmoke;
            route4.BackgroundColor = Color.WhiteSmoke;
            route5.BackgroundColor = Color.WhiteSmoke;
            fietsroute1.BackgroundColor = Color.WhiteSmoke;
            fietsroute2.BackgroundColor = Color.WhiteSmoke;
            fietsroute3.BackgroundColor = Color.WhiteSmoke;
            fietsroute4.BackgroundColor = Color.WhiteSmoke;
            fietsroute5.BackgroundColor = Color.Beige;
        }

    }
}

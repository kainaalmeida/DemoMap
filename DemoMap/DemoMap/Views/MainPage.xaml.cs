using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace DemoMap.Views
{
    public partial class MainPage : ContentPage
    {
        Polyline polyline = new Polyline();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    var position = new Position(location.Latitude, location.Longitude);
                    maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(0.1)));
                    //maps.Pins.Add(new Pin { Position = position, Label = "My House" });

                    var line = InsertPolygonInMap(position);
                    var line2 = InsertPolygonInMap(position);
                    maps.Polylines.Add(line2);

                    if (!CrossGeolocator.Current.IsListening)
                    {
                        await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(10), 1, true);
                    }

                    CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        Polyline InsertPolygonInMap(Position position)
        {

            polyline.Positions.Add(position);
            polyline.StrokeWidth = 10f;
            polyline.StrokeColor = Color.Red;


            return polyline;

        }

        private async void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = new Position(e.Position.Latitude, e.Position.Longitude);

            if (polyline.Positions?.Count >= 2)
            {
                var pos = new Position(polyline.Positions.Last().Latitude, polyline.Positions.Last().Longitude);
                if (pos != position)
                {
                    var line = InsertPolygonInMap(position);
                    maps.Polylines.Add(line);

                }

            }

        }
    }
}
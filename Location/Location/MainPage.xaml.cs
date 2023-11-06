using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Location
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void GetAndDisplayLocation(object sender,EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    locationLabel.Text = $"Location: 緯度Latitude {location.Latitude}, 經度Longitude {location.Longitude}";
                }
                else
                {
                    locationLabel.Text = "Unable to get location";
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                locationLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}

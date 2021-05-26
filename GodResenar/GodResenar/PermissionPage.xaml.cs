using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermissionPage : ContentPage
    {
        public PermissionPage()
        {
            InitializeComponent();
        }

        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            bool permissionCheck = await PermissionCheck();

            if (permissionCheck)
            {
                await Navigation.PushAsync(new ProfilePage(), true);
            }
        else
            {
               await DisplayAlert("Fel!", "Innan du fortsätter, måste du ge alla tillstånd!", "OK");
            }
        }

        private async Task<bool> PermissionCheck()
        {
            var location = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            var camera = await Permissions.CheckStatusAsync<Permissions.Camera>();
            var microphone = await Permissions.CheckStatusAsync<Permissions.Microphone>();
            var storageWrite = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (location == PermissionStatus.Granted &&
                camera == PermissionStatus.Granted &&
                microphone == PermissionStatus.Granted &&
                storageWrite == PermissionStatus.Granted)
            {
                return true;
            }
            else return false;
        }
        private async void CameraPermission_Tapped(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if  (status == PermissionStatus.Granted)
            {
                CameraPermission.BackgroundColor = Color.Green;
                CameraPermission.IsEnabled = false;
                CameraPermission.Text = "OK";
            }
        }

        private async void MicrophonePermission_Tapped(object sender, EventArgs e)
        {
            if (await Permissions.RequestAsync<Permissions.Microphone>() == PermissionStatus.Granted)
            {
                MicrophonePermission.BackgroundColor = Color.Green;
                MicrophonePermission.IsEnabled = false;
                MicrophonePermission.Text = "OK";
            }

        }

        private async void StorageWritePermission_Tapped(object sender, EventArgs e)
        {
            if (await Permissions.RequestAsync<Permissions.StorageWrite>() == PermissionStatus.Granted)
            {
                StorageWritePermission.BackgroundColor = Color.Green;
                StorageWritePermission.IsEnabled = false;
                StorageWritePermission.Text = "OK";
            }
        }

        private async void LocationPermission_Tapped(object sender, EventArgs e)
        {
            if (await Permissions.RequestAsync<Permissions.LocationWhenInUse>() == PermissionStatus.Granted)
            {
                LocationPermission.BackgroundColor = Color.Green;
                LocationPermission.IsEnabled = false;
                LocationPermission.Text = "OK";
            }
        }
    }
}
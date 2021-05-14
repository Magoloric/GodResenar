using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ContinueButton.IsVisible = false;
        }

        private async void PermissionButton_Clicked(object sender, EventArgs e)
        {
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            await Permissions.RequestAsync<Permissions.Camera>();
            await Permissions.RequestAsync<Permissions.Microphone>();
            await Permissions.RequestAsync<Permissions.StorageRead>();
            await Permissions.RequestAsync<Permissions.StorageWrite>();
            await Permissions.RequestAsync<Permissions.NetworkState>();
            await Permissions.RequestAsync<Permissions.Photos>();
            ContinueButton.IsVisible = true;
        }

        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(), true);
        }
    }
}
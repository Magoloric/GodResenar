using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (VersionTracking.IsFirstLaunchEver)
            {
                Navigation.PushAsync(new IntroPage(), true);
            }
            else
            {
                Navigation.PushAsync(new LoginPage(), true);
            }
        }
    }
}
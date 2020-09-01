using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using GodResenar.Functions;

namespace GodResenar
{
    public partial class App : Xamarin.Forms.Application, INotifyPropertyChanged
    {
        
        public static INavigation GlobalNavigation { get; private set; }

        public static object UIParent { get; set; } = null;
        // UIParent used by Android version of the app
        public static object AuthUIParent = null;
        



        public App()
        {
            InitializeComponent();
            UserHandler.CretateClient();

            MainPage = new NavigationPage(new MainPage());
            AuthUIParent = MainPage;
        }

        protected override void OnStart()
        {
            VersionTracking.Track();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

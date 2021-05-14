using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;

using Vapolia.Droid.Lib.Effects;
using Microsoft.Identity.Client;
using Xamarin.Forms;
using UltimateXF.Droid;

namespace GodResenar.Droid
{
    [Activity(Label = "GodResenar", Icon = "@drawable/appicon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.SetFlags("AppTheme_Experimental", "Expander_Experimental", "IndicatorView_Experimental");
            UltimateXFSettup.Initialize(this);
            PlatformGestureEffect.Init();
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
            App.UIParent = this;
            App.AuthUIParent = this;

        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper
                .SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
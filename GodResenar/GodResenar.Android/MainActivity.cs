﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Vapolia.Droid.Lib.Effects;
using Microsoft.Identity.Client;
using Xamarin.Forms;

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
            PlatformGestureEffect.Init();
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
            App.UIParent = this;
            App.AuthUIParent = this;

        }
    }
}
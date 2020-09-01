using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportSentPage : ContentPage
    {
        public ReportSentPage()
        {
            InitializeComponent();
        }

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(), true);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new ProfilePage(), true);
            return false;
        }
    }
}
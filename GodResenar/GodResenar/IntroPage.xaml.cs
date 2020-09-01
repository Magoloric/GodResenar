using GodResenar.Functions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        OnboardingHandler obh = new OnboardingHandler(); 
        public IntroPage()
        {
            
            InitializeComponent();
            string SkipButtonText = obh.SkipButtonText;  
        }

        private void SkipButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage(), true);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopToRootAsync();
            return false;
        }
    }
}

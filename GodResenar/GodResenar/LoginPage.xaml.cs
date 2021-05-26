using GodResenar.Functions;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Navigation.PopToRootAsync();
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Temporary, until I write the netcode
            UserHandler.GetUserInfo(null);
            if (VersionTracking.IsFirstLaunchEver)
            {
                await Navigation.PushAsync(new PermissionPage(), true);
            }
            else
            {
                await Navigation.PushAsync(new ProfilePage(), true);
            }
            /*
            string result;
            try
            {
                result = await UserHandler.AuthUser();
                if (result != null)
                {
                    await DisplayAlert("Fel!", "Ett fel har inträffat: " + result, "OK");
                }
                await Navigation.PushAsync(new ProfilePage());
            }
            catch (MsalException ex)
            {
                if (ex.Message != null && ex.Message.Contains("AADB2C90118"))
                {
                    result = await OnForgotPassword();

                    await Navigation.PushAsync(new ProfilePage());
                }
                else if (ex.ErrorCode != "authentication_canceled")
                {
                    await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
                }
            }*/
        }
        /*
    async Task<string> OnForgotPassword()
    {
        try
        {
            return await UserHandler.ResetPassword();
        }
        catch (MsalException)
        {
            return null;
        }
    }
        */
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopToRootAsync();
            return false;
        }
        /*
        protected override async void OnAppearing()
        {
            try
            {
                IEnumerable<IAccount> accounts = await UserHandler.PCA.GetAccountsAsync();

                AuthenticationResult result = await UserHandler.PCA
                    .AcquireTokenSilent(Identities.B2cscopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
                UserHandler.GetUserInfo(result);
                await Navigation.PushAsync(new ProfilePage(), true);
            }
            catch (Exception ex)
            {
                base.OnAppearing();
            }
        }
        */
    }
    
}
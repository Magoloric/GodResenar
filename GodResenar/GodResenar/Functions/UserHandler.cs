using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

namespace GodResenar.Functions
{
    class UserHandler
    {
        //To be reimplemented later, depending on environment requirements
        public static IPublicClientApplication PCA { get; private set; }
        // Keychain security group used by iOS version of the app
        public static string iOSKeychainSecurityGroup = null;
        public bool isLoggedin = false;
        // Microsoft Authentication client for native/mobile apps
        private static IEnumerable<IAccount> currentAccounts;
        private static AuthenticationResult authResult;

        public static void CretateClient ()
        {

            var builder = PublicClientApplicationBuilder
         .Create(Identities.ClientId)
        .WithTenantId(Identities.TenantId)
        .WithB2CAuthority(Identities.AuthoritySignin)
        .WithRedirectUri(Identities.MsalUri);

            if (!string.IsNullOrEmpty(iOSKeychainSecurityGroup))
            {
                builder = builder.WithIosKeychainSecurityGroup(iOSKeychainSecurityGroup);
            }

            PCA = builder.Build();
        }

        public static async Task<string> AuthUser()
        {
            currentAccounts = await PCA.GetAccountsAsync();
            try
            {
                authResult = await PCA
                    .AcquireTokenSilent(Identities.B2cscopes, currentAccounts.FirstOrDefault())
                    .ExecuteAsync();
                GetUserInfo(authResult);

            }
            catch (MsalUiRequiredException msalEx)
            {
                var interactiveRequest = PCA.AcquireTokenInteractive(Identities.B2cscopes);

                if (App.AuthUIParent != null)
                {
                    interactiveRequest = interactiveRequest
                        .WithParentActivityOrWindow(App.AuthUIParent);
                }

                authResult = await interactiveRequest.ExecuteAsync();
                GetUserInfo(authResult);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        public static async Task<string> ResetPassword()
        {
            await PCA
                   .AcquireTokenInteractive(Identities.Scopes)
                   .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                   .WithParentActivityOrWindow(App.UIParent)
                   .WithB2CAuthority(Identities.AuthorityPasswordReset)
                   .ExecuteAsync();
            return null;
        }

        public static async Task<AuthenticationResult> RegisterUser()
        {
            return await PCA
                   .AcquireTokenInteractive(Identities.Scopes)
                   .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                   .WithParentActivityOrWindow(App.UIParent)
                   .ExecuteAsync();
        }
        public static void GetUserInfo(AuthenticationResult authResult)
        {

            var token = authResult.IdToken;
            var payload = Jose.JWT.Payload(token);

            var payloadJSON = JObject.Parse(payload);
            User.UserName = payloadJSON.Value<String>("name");

            //Placeholder data, will be fixed as soon as I find a way to get all the user data
            User.Email = "info@magolor.ic";
            User.Phone = "+123456789";
            User.PointSaldo = 4425;
            User.PointsCollected = 7244;
            User.UserLevel = 7;
            User.UserPic = new Xamarin.Forms.Image
            {
                Source = "ic_person_outline_green_900_36dp.png"
            };
            User.ReportsAccepted = 13;
            User.ReportsSent = 20;

        }  
    }
}

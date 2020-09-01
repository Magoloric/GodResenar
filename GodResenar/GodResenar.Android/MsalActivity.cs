
using Android.App;
using Android.Content;

using Microsoft.Identity.Client;

namespace GodResenar.Droid
{
    [Activity]
    [IntentFilter(new[] { Intent.ActionView },
  Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
  DataHost = "auth",
  DataScheme = "msal82fd9d11-c7f6-4289-ae76-884f2833f4af")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
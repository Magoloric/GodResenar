namespace GodResenar.Functions
{
    class Identities
    {
        static readonly string tenantName = "godresenarb2c";
        static readonly string tenantId = "10e6d694-a19f-4381-b4ea-6cf463e63cac";
        static readonly string clientId = "82fd9d11-c7f6-4289-ae76-884f2833f4af";
        static readonly string policySignin = "B2C_1_gr_signupsignin";
        static readonly string policyPassword = "B2C_1_gr_passwordreset";
        static readonly string policyEdit = "B2C_1_gr_profileedit";
        static readonly string iosKeychainSecurityGroup = "com.magnumfrog.godresenar";

        static readonly string[] scopes = { "User.Read", "User.ReadWrite"};
        static readonly string[] b2cscopes = { "https://godresenarb2c.onmicrosoft.com/api/readuserdata", "https://godresenarb2c.onmicrosoft.com/api/writeuserdata" };
        static readonly string authorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/B2C_1_gr_signupsignin/v2.0";
        static readonly string msalUri = "msal" + ClientId + "://auth";

        public static string TenantName => tenantName;

        public static string TenantId => tenantId;

        public static string ClientId => clientId;

        public static string PolicySignin => policySignin;

        public static string PolicyPassword => policyPassword;

        public static string PolicyEdit => policyEdit;
        public static string[] Scopes => scopes;

        public static string AuthoritySignin
        {
            get
            {
                return $"{AuthorityBase}{policySignin}";
            }
        }
        public static string AuthorityPasswordReset
        {
            get
            {
                return $"{AuthorityBase}{policyPassword}";
            }
        }

        public static string IosKeychainSecurityGroup => iosKeychainSecurityGroup;

        public static string[] B2cscopes => b2cscopes;

        public static string MsalUri => msalUri;

        public static string AuthorityBase => authorityBase;
    }
}

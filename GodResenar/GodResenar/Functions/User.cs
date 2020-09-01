using Xamarin.Forms;

namespace GodResenar.Functions
{
    class User
    {
        private static string userName;
        private static Image userPic;
        private static int userLevel;
        private static int pointsCollected;
        private static int pointSaldo;
        private static string email;
        private static string phone;
        private static int reportsSent;
        private static int reportsAccepted;

        public static string UserName { get => userName; set => userName = value; }
        public static Image UserPic { get => userPic; set => userPic = value; }
        public static int UserLevel { get => userLevel; set => userLevel = value; }
        public static int PointsCollected { get => pointsCollected; set => pointsCollected = value; }
        public static int PointSaldo { get => pointSaldo; set => pointSaldo = value; }
        public static string Email { get => email; set => email = value; }
        public static string Phone { get => phone; set => phone = value; }
        public static int ReportsSent { get => reportsSent; set => reportsSent = value; }
        public static int ReportsAccepted { get => reportsAccepted; set => reportsAccepted = value; }

        public static string PointsAndLevel()
        {
            return pointsCollected + " poäng (Nivå " + userLevel + ")";
        }

    }
}

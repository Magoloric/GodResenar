
using GodResenar.Functions;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;

namespace GodResenar
{

    [DesignTimeVisible(false)]

    public partial class ProfilePage : ContentPage
    {
        string userName = User.UserName;
        string pointsAndLevel = User.PointsAndLevel();
        int currentLevel = User.UserLevel;
        int nextLevel = User.UserLevel + 1;
        float levelProgress = (float)(User.PointsCollected - (User.UserLevel * 1000)) / 1000;
        int nrOfReports = User.ReportsSent;
        int nrOfAcceptedReports = User.ReportsAccepted;
        int saldo = User.PointSaldo;

        public string UserName { get => userName; set => userName = value; }
        public string PointsAndLevel { get => pointsAndLevel; set => pointsAndLevel = value; }
        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public int NextLevel { get => nextLevel; set => nextLevel = value; }
        public int NrOfReports { get => nrOfReports; set => nrOfReports = value; }
        public int NrOfAcceptedReports { get => nrOfAcceptedReports; set => nrOfAcceptedReports = value; }
        public float LevelProgress { get => levelProgress; set => levelProgress = value; }
        public int Saldo { get => saldo; set => saldo = value; }

        //ICONS
        public const string Cart = "\U000f0110";
        public const string Pencil = "\U000f03eb";
        public const string BulletinBoard = "\U000f00e5";
        public const string Wrench = "\U000f05b7";
        public ProfilePage()
        {
            BindingContext = this;
            if (User.UserName == "" || User.UserName == null)
            {
                userName = "Olof Svensson";
                pointsAndLevel = " 2665 Poäng totalt";
                nrOfAcceptedReports = 23;
                nrOfReports = 57;
                saldo = 1665;
                levelProgress = 0.23f;
                currentLevel = 6;
            }
            else
            {
                LevelProgress = (float)Math.Round(LevelProgress, 1);
            }
        InitializeComponent();
            initDiagrams();
            setLevelColor();
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopToRootAsync();
            return false;
        }
        async void SettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), true);
        }
        async void NewReportButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage(), true);
        }
        async void FlowButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlowPage(), true);
        }

        async void ShopButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShopPage(), true);
        }

        public void setLevelColor()
        {
            switch(currentLevel)
            {
                case int n when (n > 0 && n <= 5):
                    LevelIndicatorColor.BorderColor = Color.Red;
                    break;
                case int n when (n > 5 && n <= 10):
                    LevelIndicatorColor.BorderColor = Color.Purple;
                    break;
                case int n when (n > 10 && n <= 15):
                    LevelIndicatorColor.BorderColor = Color.Blue;
                    break;
                case int n when (n > 15 && n <= 20):
                    LevelIndicatorColor.BorderColor = Color.Green;
                    break;
                case int n when (n > 20 && n <= 25):
                    LevelIndicatorColor.BorderColor = Color.Yellow;
                    break;
                case int n when (n > 25 && n <= 30):
                    LevelIndicatorColor.BorderColor = Color.Orange;
                    break;
                case int n when (n > 30 && n <= 35):
                    LevelIndicatorColor.BorderColor = Color.Silver;
                    break;
                case int n when (n > 35 && n <= 49):
                    LevelIndicatorColor.BorderColor = Color.Gold;
                    break;
                case int n when (n >= 40):
                    LevelIndicatorColor.BorderColor = Color.Turquoise;
                    break;
                default:
                    LevelIndicatorColor.BorderColor = Color.Black;
                    break;
            }
        }
        public void initDiagrams()
        {

            var entries = new[]
            {
                new ChartEntry(NrOfReports)
                {
                    Label = "Övriga",
                    ValueLabel = NrOfReports.ToString(),
                    Color = SKColor.Parse("#EDE456"),
                    TextColor = SKColor.Parse("#EDE456"),
                    ValueLabelColor = SKColor.Parse("#EDE456")
                },
                new ChartEntry(NrOfAcceptedReports)
                {
                    Label = "Accepterade",
                    ValueLabel = NrOfAcceptedReports.ToString(),
                    Color = SKColor.Parse("#529262"),
                    TextColor = SKColor.Parse("#529262"),
                    ValueLabelColor = SKColor.Parse("#529262")
                }
            };
            var chart = new DonutChart { Entries = entries };
            chartView.Chart = chart;
            chart.BackgroundColor = SKColor.Empty;
            chart.LabelTextSize = 40;
            chart.LabelColor = SKColors.White;
            chart.LabelMode = LabelMode.RightOnly;
        }
    }
}

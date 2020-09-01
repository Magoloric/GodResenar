
using GodResenar.Functions;
using Java.Util.Jar;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowPage : ContentPage
    {

        ReportHandler rh = new ReportHandler();
        ObservableCollection<Report> rc = new ObservableCollection<Report>();
        enum SortBy { 
            Date,
            Votes
        };
        enum FilterBy { 
            All,
            Arvika,
            Eda,
            Filipstad,
            Forshaga,
            Grums,
            Hagfors,
            Hammaro,
            Karlstad,
            Kil,
            Kristinehamn,
            Munkfors,
            Storfors,
            Sunne,
            Saffle,
            Torsby,
            Arjang,
            Bus,
            Train,
            Infrastructure,
            Suggestions
        };

        public FlowPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PushReports();
            ReportCollectionView.ItemsSource = rc;
        }

        public void PushReports() {
            rh.GetReports();
            rc = rh.ReportDB;

            if (rc.Count < 1)
            {
                Label noPosts = new Label();
                noPosts.TextColor = Color.DarkGray;
                noPosts.Text = "Finns inga poster att visa just nu! Kika gärna senare!";
                noPosts.FontAttributes = FontAttributes.Bold;
                ReportCollectionView.AddLogicalChild(noPosts);
            }
            else
            {

            }

        }

        private void FilterButton_Clicked(object sender, System.EventArgs e)
        {

        }

        private void SortButton_Clicked(object sender, System.EventArgs e)
        {

        }

        private void ReportCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void VoteButton_Clicked(object sender, System.EventArgs e)
        {

        }

        private void Entry_Tapped(object sender, System.EventArgs e)
        {
            
        }

    }
}
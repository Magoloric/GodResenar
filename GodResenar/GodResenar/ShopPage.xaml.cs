using GodResenar.Functions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using UltimateXF.Widget.Charts.Models.PieChart;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Internals;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ShopPage : ContentPage
    {

        ShopHandler sh = new ShopHandler();
        public event PropertyChangedEventHandler PropertyChanged;
        private int saldo = User.PointSaldo;
        public int Saldo
        {
            private set
            {
                if (saldo != value)
                {
                    saldo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Saldo"));
                }
            }
            get
            {
                return saldo;
            }
        }

        private bool availabilty;
        public ShopPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PushItems();
            ItemCollectionView.ItemsSource = sh.Items;
        }

        public void PushItems()
        {
            sh.getShopItems();

            if (sh.Items.Count < 1)
            {
                Label noPosts = new Label();
                noPosts.TextColor = Color.DarkGray;
                noPosts.Text = "Finns inga produkter att visa just nu! Kika gärna senare!";
                noPosts.FontAttributes = FontAttributes.Bold;
                ItemCollectionView.AddLogicalChild(noPosts);
            }
        }

        private void FlowEntry_Tapped(object sender, System.EventArgs e)
        {

        }

        private async void BuyButton_Clicked(object sender, System.EventArgs e)
        {
            var ClickedItem = (Button)sender;
            var ClickedITemContext = (ShopItem)ClickedItem.BindingContext;
            int ItemPrice = ClickedITemContext.Price;
            string ItemName = ClickedITemContext.Name;


            if (User.PointSaldo < ItemPrice)
            {
                await DisplayAlert("Köpet misslyckades!", "För lite poäng på kontot!", "Tillbaka");
            }
            else
            {
                bool answer = await DisplayAlert("Är du säker", "Vill du köpa " + ItemName + "?", "Ja", "Nej");
                if (answer)
                {
                    User.PointSaldo -= ItemPrice;
                    UserHandler.UpdateUserData();
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
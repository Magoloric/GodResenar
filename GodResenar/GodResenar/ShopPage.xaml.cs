using GodResenar.Functions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {
        ShopHandler sh = new ShopHandler();
        public ShopPage()
        {
            InitializeComponent();
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
            else
            {

            }
        }

        private void FlowEntry_Tapped(object sender, System.EventArgs e)
        {

        }

        private void BuyButton_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
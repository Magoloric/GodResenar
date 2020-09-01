using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GodResenar.Functions
{
    public class OnboardingHandler : MvvmHelpers.BaseViewModel
    {
        private ObservableCollection<Onboarding> items;
        private int position;
        private string skipButtonText;

        public OnboardingHandler()
        {
            SetSkipButtonText("Skippa");
            InitializeOnBoarding();
            InitializeSkipCommand();
        }
        public ObservableCollection<Onboarding> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }
        private void SetSkipButtonText(string skipButtonText)
            => SkipButtonText = skipButtonText;

        private void InitializeOnBoarding()
        {
            Items = new ObservableCollection<Onboarding>
            {
                new Onboarding
                {
                    Title = "Trasig biljettmaskin? Försenad buss? Farlig läge på busshållsplatsen?",
                    Content = "GodResenär låter dig rapportera alla problem du råkar stöta på när du reser med Värmlandstrafik",
                    //Img = "healthy_habits.svg"
                },
                new Onboarding
                {
                    Title = "Fota, filma, rapportera!",
                    Content = "Vi behandlar ditt ärende och ser till att underleverantörer fixar det!",
                    //ImageUrl = "time.svg"
                },
                new Onboarding
                {
                    Title = "Bli belönad!",
                    Content = "Du blir belönad med poängen för varje ärende som vi behandlar. Ju viktigare ärendet är, desto fler poäng får du!"
                    //ImageUrl = "visual_data.svg"
                },
                new Onboarding
                {
                    Title = "Tillsammans gör vi kollektivtrafiken i Värmland bättre!",
                    Content = "Vill du vara med? Bli medlem idag!",
                    //ImageUrl = "visual_data.svg"
                }
            };
        }

        private void InitializeSkipCommand()
        {
            SkipCommand = new Command(() =>
            {
                if (LastPositionReached())
                {
                    ExitOnBoarding();
                }
                else
                {
                    MoveToNextPosition();
                }
            });
        }

        private static void ExitOnBoarding()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void MoveToNextPosition()
        {
            var nextPosition = ++Position;
            Position = nextPosition;
        }

        private bool LastPositionReached()
            => Position == Items.Count - 1;



        public string SkipButtonText
        {
            get => skipButtonText;
            set => SetProperty(ref skipButtonText, value);
        }

        public int Position
        {
            get => position;
            set
            {
                if (SetProperty(ref position, value))
                {
                    UpdateSkipButtonText();
                }
            }
        }

        private void UpdateSkipButtonText()
        {
            if (LastPositionReached())
            {
                SetSkipButtonText("Nu kör vi!");
            }
        }

        public ICommand SkipCommand { get; private set; }
    }
}
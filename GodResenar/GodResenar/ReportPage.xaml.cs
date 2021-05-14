using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GodResenar.Functions;
using Android.Widget;
using Android.App;
using Android.Provider;

namespace GodResenar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        VoiceRecorder recorder;
        Reporter reporter;
        Camera camera;
        public ReportPage()
        {
            recorder = new VoiceRecorder();
            reporter = new Reporter();
            camera = new Camera();
            InitializeComponent();
        }

        private async void takePhoto_Clicked(object sender, System.EventArgs e)
        {
            bool success = await camera.TakePhoto();
            if (success == false)
            {
                await DisplayAlert("Alert", camera.Error, "OK");
            }
            else
            {
                imagePreview.Source = camera.Preview.Source;
                imagePlaceholder.IsVisible = false;
                imagePreview.IsVisible = true;
                ToStepTwo();
            }
        }

        private async void takeVideo_Clicked(object sender, System.EventArgs e)
        {
            bool success = await camera.PickPhoto();
            if (success == false)
            {
                await DisplayAlert("Alert", camera.Error, "OK");
            }
            else
            {
                imagePreview.Source = camera.Preview.Source;
                imagePlaceholder.IsVisible = false;
                imagePreview.IsVisible = true;
                ToStepTwo();
            }
        }
        void ToStepTwo()
        {
            StepOne.IsVisible = false;
            StepTwo.IsVisible = true;
        }
        void ToStepOne()
        {
            StepTwo.IsVisible = false;
            StepOne.IsVisible = true;
        }

        private async void pickPhoto_Clicked(object sender, System.EventArgs e)
        {
            bool success = await camera.TakeVideo();
            if (success == false)
            {
                await DisplayAlert("Alert", camera.Error, "OK");
            }
            else
            {
                imagePreview.Source = camera.Preview.Source;
                imagePlaceholder.IsVisible = false;
                imagePreview.IsVisible = true;
                ToStepTwo();
            }
        }

        private async void pickVideo_Clicked(object sender, System.EventArgs e)
        {
            bool success = await camera.PickVideo();
            if (success == false)
            {
                await DisplayAlert("Alert", camera.Error, "OK");
            }
            else
            {
                imagePreview.Source = camera.Preview.Source;
                imagePlaceholder.IsVisible = false;
                imagePreview.IsVisible = true;
                ToStepTwo();
            }
        }

        private async void stopRecording_Clicked(object sender, System.EventArgs e)
        {
            await recorder.StopRecord();
            stopRecording.IsVisible = false;
            playAudioMessage.IsVisible = true;
            deleteAudioMessage.IsVisible = true;
        }

        private async void audioMessage_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Oj då!", "Röstinspelning är ej tillgänglig ännu!", "OK");
            /*
            MessageField.IsVisible = false;
            audioMessage.IsVisible = false;
            recordingBar.IsVisible = true;
            stopRecording.IsVisible = true;
            await recorder.StartRecord();
            */
        }

        private async void playAudioMessage_Clicked(object sender, System.EventArgs e)
        {
            await recorder.PlayMessage();
        }

        private async void deleteAudioMessage_Clicked(object sender, System.EventArgs e)
        {
            bool del = await DisplayAlert("Alert", "Vill du ta bort röstmeddelande?", "OK", "Avbryt");
            if (del == true)
            {
                recorder.RemoveMessage();
                recordingBar.IsVisible = false;
                playAudioMessage.IsVisible = false;
                deleteAudioMessage.IsVisible = false;
                MessageField.IsVisible = true;
                audioMessage.IsVisible = true;
            }
        }

        private void retakePhoto_Clicked(object sender, System.EventArgs e)
        {
            camera.RemovePreview();
            imagePlaceholder.IsVisible = true;
            imagePreview.IsVisible = false;
            MessageField.Text = "";
            recorder.RemoveMessage();
            ToStepOne();
        }

        private async void sendReport_Clicked(object sender, System.EventArgs e)
        {
            /*await reporter.SendReport(report);*/
            bool success = reporter.SendReport();

            if (success == true)
            {
                await Navigation.PushAsync(new ReportSentPage(), true);
            }
            else
            {
                await DisplayAlert("Oj då!", "Kunde inte skicka rapporten. Vänligen försök igen senare", "OK");
            }

        }
    }
}
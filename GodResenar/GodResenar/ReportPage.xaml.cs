using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GodResenar.Functions;

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
            int response = await camera.TakePhoto();
            switch (response)
            {
                case -1:
                    {
                        await DisplayAlert("Oj!", camera.Error, "OK");
                        break;
                    }
                case 0:
                    //Implies that user canceled the process
                    break;
                case 1:
                    {
                        imagePreview.Source = camera.Preview.Source;
                        imagePreview.IsVisible = true;
                        imagePlaceholder.IsVisible = false;
                        ToStepTwo();
                        break;
                    }

            }
        }

        private async void takeVideo_Clicked(object sender, System.EventArgs e)
        {
            int response = await camera.TakeVideo();
            switch (response)
            {
                case -1:
                    {
                        await DisplayAlert("Oj!", camera.Error, "OK");
                        break;
                    }
                case 0:
                    //Implies that user canceled the process
                    break;
                case 1:
                    {
                        videoPreview.Source = camera.VideoPreview.Source;
                        imagePlaceholder.IsVisible = false;
                        videoPreview.IsVisible = true;
                        ToStepTwo();
                        break;
                    }
            }
        }


        private async void pickPhoto_Clicked(object sender, System.EventArgs e)
        {
            int response = await camera.PickPhoto();
            switch (response)
            {
                case -1:
                    {
                        await DisplayAlert("Oj!", camera.Error, "OK");
                        break;
                    }
                case 0:
                    //Implies that user canceled the process
                    break;
                case 1:
                    {
                        imagePreview.Source = camera.Preview.Source;
                        imagePlaceholder.IsVisible = false;
                        imagePreview.IsVisible = true;
                        ToStepTwo();
                        break;
                    }
            }
        }

        private async void pickVideo_Clicked(object sender, System.EventArgs e)
        {
            int response = await camera.PickVideo();
            switch (response)
            {
                case -1:
                    {
                        await DisplayAlert("Oj!", camera.Error, "OK");
                        break;
                    }
                case 0:
                    //Implies that user canceled the process
                    break;
                case 1:
                    {
                        videoPreview.Source = camera.VideoPreview.Source;
                        imagePlaceholder.IsVisible = false;
                        videoPreview.IsVisible = true;
                        ToStepTwo();
                        break;
                    }
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

        private async void sendReport_Clicked(object sender, System.EventArgs e)
        {
            /*await reporter.SendReport(report);*/
            bool success = reporter.SendReport();

            if (success)
            {
                await Navigation.PushAsync(new ReportSentPage(), true);
            }
            else
            {
                await DisplayAlert("Oj då!", "Kunde inte skicka rapporten. Vänligen försök igen senare", "OK");
            }

        }

        private void moreInfoButton_Clicked(object sender, System.EventArgs e)
        {
            ToStepThree();
        }
        private void cancelButton_Clicked(object sender, System.EventArgs e)
        {
            camera.RemovePreview();
            imagePlaceholder.IsVisible = true;
            imagePreview.IsVisible = false;
            videoPreview.IsVisible = false;
            MessageField.Text = "";
            recorder.RemoveMessage();
            ToStepOne();
        }

        internal void ToStepOne()
        {
            StepTwo.IsVisible = false;
            StepThree.IsVisible = false;
            StepOne.IsVisible = true;
        }
        internal void ToStepTwo()
        {
            StepOne.IsVisible = false;
            StepTwo.IsVisible = true;
        }
        internal void ToStepThree()
        {
            StepTwo.IsVisible = false;
            StepThree.IsVisible = true;
        }

    }
}
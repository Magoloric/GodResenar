using System;
using System.Threading.Tasks;
using Plugin.AudioRecorder;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace GodResenar.Functions
{
    internal class VoiceRecorder
    {
        private bool isTimerRunning = false;
        private int seconds = 0;
        string error;
        string file;


        private AudioRecorderService recorder = new AudioRecorderService
        {
            StopRecordingAfterTimeout = true,
            TotalAudioTimeout = TimeSpan.FromSeconds(30),
            AudioSilenceTimeout = TimeSpan.FromSeconds(2)
        };

        private AudioPlayer player = new AudioPlayer();

        internal AudioRecorderService Recorder { get => recorder; set => recorder = value; }
        public bool IsTimerRunning { get => isTimerRunning; set => isTimerRunning = value; }
        public int Seconds { get => seconds; set => seconds = value; }
        internal AudioPlayer Player { get => player; set => player = value; }
        public string Error { get => error; set => error = value; }
        public string File { get => file; set => file = value; }

        internal async Task<bool> StartRecord()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Microphone>();

            if (status == PermissionStatus.Granted)
            {
                if (!Recorder.IsRecording)
                {
                    Seconds = 0;
                    IsTimerRunning = true;
                    Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                        Seconds++;

                        return IsTimerRunning;
                    });

                    Task<string> audioRecordTask = await Recorder.StartRecording();

                    await audioRecordTask;
                    return true;
                }
                else
                {
                    await StopRecord();
                    return false;
                }
            }
            else
            {
                await Permissions.RequestAsync<Permissions.Microphone>();
                return false;
            }
        }

        internal async Task StopRecord() { 
            await Recorder.StopRecording();
            file = recorder.GetAudioFilePath();
        }


        internal async Task<bool> PlayMessage()
        {
            try
            {
                if (file != null)
                {
                    await Recorder.StopRecording();
                    Player.Play(file);
                }
                return true;
            }
            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return false;
            }
        }

         internal bool RemoveMessage()
        {
            file = null;
            return true;
        }
    }
}
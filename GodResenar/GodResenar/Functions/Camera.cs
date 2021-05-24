using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Core;

namespace GodResenar.Functions
{
    internal class Camera
    {
        private Image preview;
        private MediaElement videoPreview;
        private string error;

        public Image Preview { get => preview; set => preview = value; }
        public MediaElement VideoPreview { get => videoPreview; set => videoPreview = value; }
        public string Error { get => error; set => error = value; }

        internal async Task<bool> TakePhoto()
        {
            try
            {
                if (!MediaPicker.IsCaptureSupported)
                {
                    error = "Enheten saknar kameran eller har ingen stöd för fotografering!";
                    return false;
                }
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") + ".png"
                });

                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

                preview = new Image();
                preview.Source = ImageSource.FromFile(newFile);
                return true;
            }
            catch (Exception ex)
            {
                error = $"Oops, något hände... {ex.Message}";
                return false;
            }
        }

        internal async Task<bool> TakeVideo()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                error = "Enheten saknar kameran eller har ingen stöd för videoinspelning!";
                return false;
            }
            try
            {
                var video = await MediaPicker.CaptureVideoAsync(new MediaPickerOptions()
            {
                    Title = DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") + ".mp4"
                });

                if (video == null)
                {
                    return false;
                }

                var newFile = Path.Combine(FileSystem.AppDataDirectory, video.FileName);
                using (var stream = await video.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                videoPreview = new MediaElement();
                videoPreview.Source = MediaSource.FromFile(newFile);
                return true;
            }
            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return false;
            }
        }
        internal async Task<bool> PickPhoto()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                preview = new Image();
                preview.Source = ImageSource.FromFile(photo.FullPath);

                return true;
            }

            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return false;
            }
        }
        internal async Task<bool> PickVideo()
        {

            try
            {
                var video = await MediaPicker.PickVideoAsync();

                if (video == null)
                {
                    return false;
                }
                videoPreview = new MediaElement();
                videoPreview.Source = MediaSource.FromFile(video.FullPath);

                return true;
            }

            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return false;
            }
        }


        internal void RemovePreview()
        {
                preview = null;
    }
}
}
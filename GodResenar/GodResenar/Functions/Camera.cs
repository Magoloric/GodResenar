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

        internal async Task<int> TakePhoto()
        {
            try
            {
                if (!MediaPicker.IsCaptureSupported)
                {
                    error = "Enheten saknar kameran eller har ingen stöd för fotografering!";
                    return -1;
                }
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") + ".png"
                });

                if (photo == null)
                {
                    return 0;
                }

                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                preview = new Image();
                preview.Source = ImageSource.FromFile(photo.FullPath);
                return 1;
            }
            catch (Exception ex)
            {
                error = $"Oops, något hände... {ex.Message}";
                return -1;
            }
        }

        internal async Task<int> TakeVideo()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                error = "Enheten saknar kameran eller har ingen stöd för videoinspelning!";
                return -1;
            }
            try
            {
                var video = await MediaPicker.CaptureVideoAsync(new MediaPickerOptions()
                {
                    Title = DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") + ".mp4"
                });

                if (video == null)
                {
                    return 0;
                }

                var newFile = Path.Combine(FileSystem.AppDataDirectory, video.FileName);
                using (var stream = await video.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);
                videoPreview = new MediaElement();
                videoPreview.Source = MediaSource.FromFile(video.FullPath);
                return 1;
            }
            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return -1;
            }
        }
        internal async Task<int> PickPhoto()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();

                if (photo == null)
                {
                    return 0;
                }
                preview = new Image();
                preview.Source = ImageSource.FromFile(photo.FullPath);

                return 1;
            }

            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return -1;
            }
        }
        internal async Task<int> PickVideo()
        {

            try
            {
                var video = await MediaPicker.PickVideoAsync();

                if (video == null)
                {
                    return 0;
                }
                videoPreview = new MediaElement();
                videoPreview.Source = MediaSource.FromFile(video.FullPath);

                return 1;
            }

            catch (Exception ex)
            {
                error = "Oops, något hände... " + ex.Message;
                return -1;
            }
        }


        internal void RemovePreview()
        {
            preview = null;
            videoPreview = null;
        }
    }
}
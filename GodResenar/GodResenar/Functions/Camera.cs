using Plugin.Media;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GodResenar.Functions
{
    internal class Camera
    {
        private Image preview;
        private string error;

        public Image Preview { get => preview; set => preview = value; }
        public string Error { get => error; set => error = value; }

        internal async Task<bool> TakePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                error = "Kameran verkar inte finnas på enheten!";
                return false;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Godresenar",
                Name = "GodResenar" + DateTime.Now.ToString() + "photo.jpg",
            });
            try
            {

                if (file == null)
                {
                    error = "Gick inte att spara filen! Kolla så att du har utrymme kvar för det!";
                    return false;
                }
                preview = new Image();
                preview.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
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
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                error = "Kameran verkar inte finnas på enheten!";
                return false;
            }
            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "GodResenar" + DateTime.Now.ToString() + "vid.mp4",
                Directory = "Godresenar",
            });
            try
            {
                if (file == null)
                {
                    return false;
                }
                preview = new Image();
                
                preview.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
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
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                error = "Du måste tillåta videoinspelningen innan du fortsätter!";
                return false;
            }

            var file = await CrossMedia.Current.PickVideoAsync();
            try
            {

                if (file == null)
                    return false;

                preview = new Image();
                preview.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
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
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                error = "Du måste tillåta appen att använda kameran innan du fortsätter!";
                return false;
            }
            var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);
            try
            {


                if (file == null)
                {
                    error = "Gick inte att öppna filen!";
                    return false;
                }
                preview = new Image();
                preview.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
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
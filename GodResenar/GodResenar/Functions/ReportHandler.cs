/*
 Function handles downloading and deserializing data from the server, sorting and filtering it
 */

using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace GodResenar.Functions
{
    class ReportHandler
    {

        public ObservableCollection<Report> ReportDB = new ObservableCollection<Report>();
        
        public void GetReports()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string json;
Stream stream = assembly.GetManifestResourceStream("GodResenar.Resources.sampleBase.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            ReportDB = JsonConvert.DeserializeObject<ObservableCollection<Report>>(json);

            foreach(Report element in ReportDB)
            {
                if (element.PhotoSource == "" || element.PhotoSource == null)
                {
                    element.PhotoSource = "ic_camera_enhance_green_dark_36dp";
                }
                element.PhotoAttached = new Xamarin.Forms.Image();
                element.PhotoAttached.Source = element.PhotoSource;
            }
            /*To be re-implemented for client system, JSON for proof of concept*/
        }
        void SortReports()
        {
            // Sort by votes or date
        }
        void FilterReports()
        {
            // Filter by category (perspectively even by area)
        }
    }


        
}

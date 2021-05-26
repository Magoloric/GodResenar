using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace GodResenar.Functions
{
    class Reporter
    {
        private Report report;

        internal Report Report { get => report; set => report = value; }
        internal bool SendReport()
        {
            /*
            var assembly = Assembly.GetExecutingAssembly();
            string json = JsonConvert.SerializeObject(report);
            Stream stream = assembly.GetManifestResourceStream("GodResenar.Resources.sampleBase.json");
            using (var writer = new System.IO.StreamWriter(stream))
            {

            }


           *To be re-implemented for client system, JSON for proof of concept*/

            return true;
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace GodResenar.Functions
{
    class ShopHandler
    {
        private ObservableCollection<ShopItem> items;
        internal ObservableCollection<ShopItem> Items { get => items; set => items = value; }

        public void getShopItems()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string json;
            Stream stream = assembly.GetManifestResourceStream("GodResenar.Resources.sampleShop.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            Items = JsonConvert.DeserializeObject<ObservableCollection<ShopItem>>(json);

            foreach (ShopItem element in Items)
            {
                if (element.PictureSource == "" || element.PictureSource == null)
                {
                    element.PictureSource = "ic_camera_enhance_green_dark_36dp";
                }
                element.Picture = new Xamarin.Forms.Image();
                element.Picture.Source = element.PictureSource;
            }
            /*To be re-implemented for client system, JSON for proof of concept*/
        }

    }

}

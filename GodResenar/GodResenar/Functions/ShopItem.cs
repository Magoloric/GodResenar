using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GodResenar.Functions
{
    class ShopItem
    {
        private string name;
        private string description;
        private bool availability;
        private Image picture;
        private string pictureSource;
        private int price;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool Availability { get => availability; set => availability = value; }
        public Image Picture { get => picture; set => picture = value; }
        public int Price { get => price; set => price = value; }
        public string PictureSource { get => pictureSource; set => pictureSource = value; }
    }


}

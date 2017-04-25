using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.Models
{
    class Item
    {
        public static Uri baseUri = new Uri("ms-appx:///Assets/Images/");
        public Uri UrlImage { get; set; }
        public String EnWord { get; set; }
        public String PlWord { get; set; }

        public Item(String urlImage,String enWord,String plWord)
        { 
            UrlImage = new Uri(baseUri, urlImage);
            EnWord = enWord;
            PlWord = plWord;
        }
    }
}

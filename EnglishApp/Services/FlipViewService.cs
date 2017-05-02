using EnglishApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.Services
{
    class FlipViewService
    {
        public ObservableCollection<Item> Items;
        public Dictionary<String, String> translationItems;
        public Dictionary<String, String> locatedImages;

        public FlipViewService(bool isTranslated)
        {
            if (isTranslated)
            {
                initTranslationItems();
            }

            GetProperImagesPath();
        }

        public void initTranslationItems()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            

            translationItems = new Dictionary<string, string>();

            var item = loader.GetString("TranslationCar");
            translationItems.Add("Car", item);
            Debug.WriteLine("Tłumaczenie dla Car: " + translationItems["Car"]);

            item = loader.GetString("TranslationChess");
            translationItems.Add("Chess", item);

            item = loader.GetString("TranslationDog");
            translationItems.Add("Dog", item);

            item = loader.GetString("TranslationFire");
            translationItems.Add("Fire", item);

            item = loader.GetString("TranslationGuitar");
            translationItems.Add("Guitar", item);

            item = loader.GetString("TranslationMermaid");
            translationItems.Add("Mermaid", item);

            item = loader.GetString("TranslationMotorbike");
            translationItems.Add("Motorbike", item);

            item = loader.GetString("TranslationPlane");
            translationItems.Add("Plane", item);

            item = loader.GetString("TranslationTruck");
            translationItems.Add("Truck", item);

            item = loader.GetString("TranslationWatch");
            translationItems.Add("Watch", item);

            item = loader.GetString("TruckImageName");
            translationItems.Add("TruckImageName", item);
        }

        public void GetProperImagesPath()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            locatedImages = new Dictionary<string, string>();

            var item = loader.GetString("TruckImageName");
            locatedImages.Add("TruckImageName", item);
        }

        public void initItems()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("car.jpg", "Car", translationItems["Car"]));
            Items.Add(new Item("chess.jpg", "Chess", translationItems["Chess"]));
            Items.Add(new Item("dog.jpg", "Dog", translationItems["Dog"]));
            Items.Add(new Item("fire.jpg", "Fire", translationItems["Fire"]));
            Items.Add(new Item("guitar.jpg", "Guitar", translationItems["Guitar"]));
            Items.Add(new Item("mermaid.jpg", "Mermaid", translationItems["Mermaid"]));
            Items.Add(new Item("motorbike.jpg", "Motorbike", translationItems["Motorbike"]));
            Items.Add(new Item("plane.jpg", "Plane", translationItems["Plane"]));
            Items.Add(new Item(locatedImages["TruckImageName"], "Truck", translationItems["Truck"]));
            Items.Add(new Item("watch.jpg", "Watch", translationItems["Watch"]));
        }

        public void initItemsWithoutTranslation()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("car.jpg", "Car", ""));
            Items.Add(new Item("chess.jpg", "Chess", ""));
            Items.Add(new Item("dog.jpg", "Dog", ""));
            Items.Add(new Item("fire.jpg", "Fire", ""));
            Items.Add(new Item("guitar.jpg", "Guitar", ""));
            Items.Add(new Item("mermaid.jpg", "Mermaid", ""));
            Items.Add(new Item("motorbike.jpg", "Motorbike", ""));
            Items.Add(new Item("plane.jpg", "Plane", ""));
            Items.Add(new Item(locatedImages["TruckImageName"], "Truck", ""));
            Items.Add(new Item("watch.jpg", "Watch", ""));
        }

    }
}

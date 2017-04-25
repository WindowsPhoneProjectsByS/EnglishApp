using EnglishApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.Services
{
    class FlipViewService
    {
        public ObservableCollection<Item> Items;

        public FlipViewService()
        {
            
        }

        public void initItems()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("car.jpg", "Car", "Samochód"));
            Items.Add(new Item("chess.jpg", "Chess", "Szachy"));
            Items.Add(new Item("dog.jpg", "Dog", "Pies"));
            Items.Add(new Item("fire.jpg", "Fire", "Ogień"));
            Items.Add(new Item("guitar.jpg", "Guitar", "Gitara"));
            Items.Add(new Item("mermaid.jpg", "Mermaid", "Syrena"));
            Items.Add(new Item("motorbike.jpg", "Motorbike", "Motor"));
            Items.Add(new Item("plane.jpg", "Plane", "Samolot"));
            Items.Add(new Item("truck.jpg", "Truck", "Ciężarówka"));
            Items.Add(new Item("watch.jpg", "Watch", "Zegarek"));
        }

        public void initItemsWithoutPL()
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
            Items.Add(new Item("truck.jpg", "Truck", ""));
            Items.Add(new Item("watch.jpg", "Watch", ""));
        }
    }
}

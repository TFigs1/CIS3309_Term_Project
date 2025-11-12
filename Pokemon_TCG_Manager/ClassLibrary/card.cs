using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_TCG_Manager.ClassLibrary
{
    internal class card
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }

        public card(string name, string rarity, decimal price, string imagePath, int quantity)
        {
            Name = name;
            Rarity = rarity;
            Price = price;
            ImagePath = imagePath;
            Quantity = quantity;
        }
    }
}

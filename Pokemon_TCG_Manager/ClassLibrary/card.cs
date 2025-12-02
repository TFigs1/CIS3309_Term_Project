using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_TCG_Manager.ClassLibrary
{
    public class Card
    {
        public int CardID { get; set; }            // AutoNumber (Primary Key)
        public int SetID { get; set; }             // Foreign Key from tblSets
        public string CardNumber { get; set; }     // e.g., "12/180"
        public string CardName { get; set; }       // e.g., "Charizard EX"
        public string Rarity { get; set; }         // e.g., "Ultra Rare"
        public string Supertype { get; set; }      // e.g., "Pokémon", "Trainer"
        public string Subtype { get; set; }        // e.g., "EX", "Item", "Supporter"
        public int Health { get; set; }            // HP value (can be 0 for non-Pokémon)
        public double Price { get; set; }          // Card price
        public string CardImage { get; set; }      // Filename or image path

        public int Quantity { get; set; }          // Not Stored in Card table - Used for tracking owned quantity in collections


        // Optional convenience constructor (you can use this when adding cards manually)
        public Card(int setID, string cardNumber, string cardName, string rarity, string supertype, string subtype, int health, double price, string cardImage)
        {
            SetID = setID;
            CardNumber = cardNumber;
            CardName = cardName;
            Rarity = rarity;
            Supertype = supertype;
            Subtype = subtype;
            Health = health;
            Price = price;
            CardImage = cardImage;
        }

        // Empty constructor required for database loading
        public Card() { }

        public override string ToString()
        {
            return $"{CardName} ({Rarity}) - ${Price}";
        }
    }
}


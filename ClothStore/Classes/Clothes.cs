using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
     class Clothes
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }

        public Clothes(string name, string description, string type, string size, double price)
        {
            ID = AllClothes.Id;
            AllClothes.Id++;
            Name = name;
            Color = description;
            Type = type;
            Size = size;
            Price = price;
            AllClothes.AddCloth(this);
        }
        

        public void ShowInfo()     ////Вывод информации о товаре
        {
            Console.WriteLine("+" + new string('-', 40) + "+");
            Console.WriteLine($"|{"Название",-20}|{Name,-19}|");
            Console.WriteLine($"|{"Цвет",-20}|{Color,-19}|");
            Console.WriteLine($"|{"Тип",-19} | {Type,-18}|");
            Console.WriteLine($"|{"Размер",-19} | {Size,-18}|");
            Console.WriteLine($"|{"Цена",-19} | {Price,-18}|");
            Console.WriteLine("+" + new string('-', 40) + "+");
            Console.WriteLine();
        }

    }
}

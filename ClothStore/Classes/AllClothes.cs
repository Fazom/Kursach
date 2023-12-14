using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
    static class AllClothes
    {
        public static int Id { get; set; }         ////Учёт следующего id для товара
        public static List<Clothes> clothes = new List<Clothes>();        ////List с товарами
        public static void AddCloth(Clothes cloth)      ////Добавление товара 
        {
            clothes.Add(cloth);
        }
        public static void RemoveCloth(Clothes cloth)      ////Удаление товара
        {
            clothes.Remove(cloth);
            Console.WriteLine($"товар {cloth.Name} удалён\n");
        }
        public static Clothes FindCloth(string name)       ////Поиск товара по имени
        {
            return clothes.Find(cloth => cloth.Name == name);
        }
        public static void ShowAll()    ////Вывод всех товаров в консоль
        {
            foreach(Clothes cloth in clothes)
            {
                Console.WriteLine($"Товар - {cloth.Name}: {cloth.Type}, {cloth.Color} цвет, {cloth.Size}, {cloth.Price}\n");
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
    static class Data
    {
        private static string filePathus = "users.txt";
        private static string filePathcl = "clothes.txt";
        public static void SaveUsers(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(filePathus))
            {
                foreach (var user in users)
                {
                    if (user.GetType().Name == "Customer")
                    {
                        string basketString = string.Join(",", user.basket);
                        writer.WriteLine($"{user.Name}*{user.Email}*{user.Password}*{user.AccessKey}*{basketString}");
                    }
                    else
                    {
                        writer.WriteLine($"{user.Name}*{user.Email}*{user.Password}*{user.AccessKey}");
                    }
                    
                }
            }
        }
        public static void SaveClothes(List<Clothes> cloth)
        {
            using (StreamWriter writer = new StreamWriter(filePathcl))
            {
                foreach (var cl in cloth)
                {
                    writer.WriteLine($"{cl.Name} {cl.Color} {cl.Type} {cl.Size} {cl.Price}");
                }
            }
        }

        public static void LoadUser()
        {
            if (File.Exists(filePathus))
            {
                using (StreamReader reader = new StreamReader(filePathus))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('*');
                        if (parts.Length > 3)
                        {
                            string name = parts[0];
                            string email = parts[1];
                            string password = parts[2];
                            byte AccessKey = byte.Parse(parts[3]);

                            if (AccessKey == 0)
                            {
                                List<int> basket = parts[4].Split(',').Select(int.Parse).ToList();
                                new Customer(name, email, password, AccessKey, basket);
                            }
                            if (AccessKey == 1)
                            {
                                new Employee(name, email, password, AccessKey);
                            }
                            if (AccessKey == 2)
                            {
                                new Admin(name, email, password, AccessKey);
                            }

                        }
                    }
                }
            }
        }

        public static void LoadCloth()
        {
            if (File.Exists(filePathcl))
            {
                using (StreamReader reader = new StreamReader(filePathcl))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 5)
                        {
                            string name = parts[0];
                            string color = parts[1];
                            string type = parts[2];
                            string size = parts[3];
                            double price = double.Parse(parts[4]);   
                            
                            new Clothes(name,color,type,size,price);
                            

                        }
                    }
                }
            }
        }


    }
}

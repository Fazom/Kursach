using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothStore.Classes;

namespace ClothStore
{


    internal class Program
    {
        public static int selectid = 0;
        public static string selectname;
        public static void Enter()   /////////////Функция для авторизации пользователя
        {
            while (true)
            {
                Console.WriteLine("Имя: ");
                string name = Console.ReadLine();
                Console.WriteLine("Пароль: ");
                string pass = Console.ReadLine();
                if (AllUser.FindUser(name) != null)
                {
                    User usr = AllUser.FindUser(name);
                    if (usr.Password == pass)
                    {
                        selectid = usr.ID;
                        Console.WriteLine("Вы успешно вошли\n");
                        selectname = name;
                        break;
                    }
                    else
                        Console.WriteLine("Неправильный пароль\n");
                }
                else
                {
                    Console.WriteLine("Такого пользователя не существует");
                    Console.WriteLine("Хотите зарегистрироваться или попробовать снова? \n 1- регистрация 2- поробовать снова\n");
                    string d = Console.ReadLine();
                    if (d == "1")
                    {
                        Registration();
                    }
                }
            }
        }

        public static void Registration()    ///////////////Функция для авторизации
        {
            Console.WriteLine("Введите имя");
            string name;
            while (true)
            {
                name = Console.ReadLine();
                User usr = AllUser.FindUser(name);
                if(usr != null)
                {
                    Console.WriteLine("Введите новое имя, текущее занято");
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine("Введите почту");
            string email = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string pass = Console.ReadLine();
            Customer newcustomer = new Customer(name,email,pass,0);
            Data.SaveUsers(AllUser.persons);
            selectname = name;
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            Data.LoadCloth();      ////Загрузка списка с товарами
            Data.LoadUser();       ////Загрузка списка с пользователями
            Console.WriteLine("Здравствуйте! Вы находитесь в магазины одежды streetwear <<Ruskiy>>");
            Console.WriteLine("Войдите в систему или зарегистрируйтесь\n");
                
            Console.WriteLine("1- Войти 2 - Зарегистрироваться\n");
            int variant = int.Parse(Console.ReadLine());
            if (variant == 1)
            {
                Enter();
            }
            else if (variant == 2)
            {
                Registration();
            }
            Console.Clear();
            User sUser = AllUser.FindUser(selectname);      /////Программа запоминает текущего пользователя
            if (sUser.GetType().Name == "Admin")            /////Функционал Админа
            {
                while(true)
                {
                    
                    Console.WriteLine();
                    Console.WriteLine($"Приветствуем вас Админ {sUser.Name}\n");
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1 - Добавить сотрудника");
                    Console.WriteLine("2 - Уволить сотрудника");
                    Console.WriteLine("3 - Все сотрудники\n");
                    string num = Console.ReadLine();
                    if (num == "1")
                    {
                        Console.Clear();
                        string name;
                        string email;
                        string pass;
                        Console.WriteLine("|Добавление сотрудника|\n");
                        Console.WriteLine("Введите имя сотрудника: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите почту сотрудника: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Введите пароль сотрудника: ");
                        pass = Console.ReadLine();
                        Employee newemployee = new Employee(name, email, pass,1);
                        Data.SaveUsers(AllUser.persons);
                    }
                    else if (num == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Напишите имя сотрудника для увольнения");
                        string name = Console.ReadLine();
                        AllUser.RemoveUser(AllUser.FindUser(name));
                        Data.SaveUsers(AllUser.persons);
                    }
                    else if (num == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("|Список сотрудников|\n");
                        foreach (User emp in AllUser.persons)
                        {
                            if(emp.GetType().Name == "Employee")
                            {
                                Console.WriteLine($"{emp.Name}, {emp.Email}, {emp.Password}\n");
                            }
                            
                        }
                    }
                }                
            }
            else if (sUser.GetType().Name == "Employee")        ////Функционал Работника
            {
                Console.WriteLine($"Приветствуем вас Работник {sUser.Name}\n");
                while(true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1 - Добавить товар");
                    Console.WriteLine("2 - Удалить товар");
                    Console.WriteLine("3 - Посмотреть все товары\n");
                    string num = Console.ReadLine();
                    if (num == "1")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        string name;
                        string color;
                        string type;
                        string size;
                        double price;
                        Console.WriteLine("|Добавление товара|\n");
                        Console.WriteLine("Введите название: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите цвет: ");
                        color = Console.ReadLine();
                        Console.WriteLine("Введите тип товара: ");
                        type = Console.ReadLine();
                        Console.WriteLine("Введите размер: ");
                        size = Console.ReadLine();
                        Console.WriteLine("Введите цену: ");
                        price = double.Parse(Console.ReadLine());
                        Clothes newClothes = new Clothes(name, color, type, size, price);
                        Data.SaveClothes(AllClothes.clothes);
                        Console.Clear();
                        Console.WriteLine($"Товар {newClothes.Name} добавлен");
                        Console.WriteLine();
                    }
                    else if (num == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("|Удаление товара|\n");
                        Console.WriteLine("Введите название товара для удаления");
                        string name = Console.ReadLine();                        
                        AllClothes.RemoveCloth(AllClothes.FindCloth(name));
                        Data.SaveClothes(AllClothes.clothes);
                        Console.WriteLine();
                    }
                    else if (num == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("|Просмотр всех товаров|\n");
                        AllClothes.ShowAll();
                    }
                }
            }
            else                    ////////Функционал Пользователя
            {
                Console.WriteLine($"Приветствуем вас {sUser.Name}");
                Console.WriteLine("Выберите действие:");
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Начать просмотр товаров");
                    Console.WriteLine("2 - Зайти в корзину");
                    string c = Console.ReadLine();
                    if (c == "1")
                    {
                        Console.Clear();
                        while (true)
                        {
                            Random random = new Random();
                            int randindex = random.Next(AllClothes.clothes.Count);
                            while(true)
                            {
                                if (randindex == 0)
                                    randindex = random.Next(AllClothes.clothes.Count);
                                else
                                    break;
                            }
                            Clothes cloth = AllClothes.clothes[randindex];
                            cloth.ShowInfo();
                            Console.WriteLine();
                            Console.WriteLine("1 - добавить в корзину");
                            Console.WriteLine("2 - следующая вещь");
                            Console.WriteLine("3 - выйти");
                            string n = Console.ReadLine();
                            if (n == "1")
                            {
                                Console.Clear();
                                sUser.basket.Add(cloth.ID);
                                Console.WriteLine("Добавлено");
                                Data.SaveUsers(AllUser.persons);
                            }
                            else if (n == "2")
                            {
                                Console.Clear();
                            }
                            else if (n == "3")
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        
                    }
                    if (c == "2")
                    {
                        Console.Clear();
                        foreach (int id in sUser.basket)
                        {
                            if (id == 0)
                            {
                                continue;
                            }
                            AllClothes.clothes[id].ShowInfo();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Сделать заказ - 1");
                        Console.WriteLine("Выйти - 2");
                        string d = Console.ReadLine();
                        if (d == "1")
                        {                            
                            double sum = 0;
                            foreach (int id in sUser.basket)
                            {
                                if (id == 0)
                                {
                                    continue;
                                }
                                sum += AllClothes.clothes[id].Price; 
                            }
                            Console.WriteLine($"Заказ вышел на {sum} рублей");
                            sUser.basket = new List<int>();
                            sUser.basket.Add(0);
                            Data.SaveUsers(AllUser.persons);
                        }
                    }
                }                
            }          
        }
       
    }
}

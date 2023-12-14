using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
    static class AllUser
    {
        public static List<User> persons = new List<User>(); ////List всех пользователей
        public static void AddUser(User user)     ////Добавление пользователя
        {
            persons.Add(user);
        }
        public static void RemoveUser(User user)     ////Удаление пользователя
        {
            persons.Remove(user);
            Console.WriteLine($"Пользователь {user.Name} удалён\n");
        }
        public static User FindUser(int id)         ////Поиск по id
        {
            return persons.Find(user => User.Id == id);
        }
        public static User FindUser(string name)     ////Поиск по имени
        {
            return persons.Find(user => user.Name == name);
        }

    }
}

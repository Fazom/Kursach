using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
    abstract class User
    {
        public static int Id { get; set; }
        public abstract int ID { get; set; }
        public abstract string Name { get; set; }
        public abstract string Email { get; set; }
        public abstract string Password { get; set; }
        public abstract byte AccessKey { get; set; }
        public List<int> basket = new List<int>();


    }
}

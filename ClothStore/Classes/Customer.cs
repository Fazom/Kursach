﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Classes
{
    class Customer : User
    {
        public override int ID { get; set; }
        public override string Name { get ; set ; }
        public override string Email { get ; set ; }
        public override string Password { get; set; }
        public override byte AccessKey { get; set; }

        public Customer(string name, string email, string password, byte accesKey, List<int> Basket)
        {
            ID = User.Id;
            User.Id++;
            basket = Basket;
            AccessKey = accesKey;
            Name = name;
            Email = email;
            Password = password;
            basket.Add(0);
            AllUser.AddUser(this);
        }
        public Customer(string name, string email, string password, byte accesKey)
        {
            ID = User.Id;
            User.Id++;
            AccessKey = accesKey;
            Name = name;
            Email = email;
            Password = password;
            basket.Add(0);
            AllUser.AddUser(this);
        }
    }
}
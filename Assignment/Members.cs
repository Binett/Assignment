using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Members
    {
        //Skapa relevanta fält
        private string firstName;
        private string lastName;
        private int height;
        private int age;
        private string city;
        private string hobby;
        private string favoriteFood;
        private string favoriteBeverage;
        private string music;
        private int children;
        private string drive;
        //Ge dom propertys
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Height { get => height; set => height = value; }
        public int Age { get => age; set => age = value; }
        public string City { get => city; set => city = value; }
        public string Hobby { get => hobby; set => hobby = value; }
        public string FavoriteFood { get => favoriteFood; set => favoriteFood = value; }
        public string FavoriteBeverage { get => favoriteBeverage; set => favoriteBeverage = value; }
        public string Music { get => music; set => music = value; }
        public int Children { get => children; set => children = value; }
        public string Drive { get => drive; set => drive = value; }

        // Skapa en konstruktor
        public Members(string firstName,string lastName,int height,int age,string city,string hobby,string favouriteFood,string favouriteBeverage,string music,int chlidren,string drive)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Height = height;
            this.Age = age;
            this.City = city;
            this.Hobby = hobby;
            this.FavoriteFood = favouriteFood;
            this.FavoriteBeverage = favouriteBeverage;
            this.Music = music;
            this.Children = chlidren;
        }
    }
}

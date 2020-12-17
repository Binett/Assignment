using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Members
    {

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|------------------------------------------------> Skapa relevanta fält för klassen <---------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        private string name;        
        private int height;
        private int age;
        private string city;
        private string hobby;
        private string favoriteFood;
        private string favoriteBeverage;
        private string music;
        private int children;
        private string drive;

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-----------------------------------------------------------------> Propertys <---------------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|


        public string Name { get => name; set => name = value; }        
        public int Height { get => height; set => height = value; }
        public int Age { get => age; set => age = value; }
        public string City { get => city; set => city = value; }
        public string Hobby { get => hobby; set => hobby = value; }
        public string FavoriteFood { get => favoriteFood; set => favoriteFood = value; }
        public string FavoriteBeverage { get => favoriteBeverage; set => favoriteBeverage = value; }
        public string Music { get => music; set => music = value; }
        public int Children { get => children; set => children = value; }
        public string Drive { get => drive; set => drive = value; }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-----------------------------------------------------------> Konstruktor <-------------------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        public Members(string firstName,int height,int age,string city,string hobby,string favouriteFood,string favouriteBeverage,string music,int chlidren,string drive)
        {
            this.Name = firstName;            
            this.Height = height;
            this.Age = age;
            this.City = city;
            this.Hobby = hobby;
            this.FavoriteFood = favouriteFood;
            this.FavoriteBeverage = favouriteBeverage;
            this.Music = music;
            this.Children = chlidren;
            this.Drive = drive;
        }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|----------------------------------> Overide toString för att visa info om medlemmarna <------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        public override string ToString()
        {
            return $"Namn:\t\t {Name}\n" +
                $"Ålder:\t\t {Age} år gammal\n" +
                $"Längd:\t\t {Height} cm\n" +
                $"Bor:\t\t {City}\n" +
                $"Hobby:\t\t {Hobby}\n" +
                $"Favorit mat:\t {FavoriteFood}\n" +
                $"Favorit dryck:\t {FavoriteBeverage}\n" +
                $"Musik:\t\t {Music}\n" +
                $"Antal barn:\t {Children}\n" +
                $"Största driv:\t {Drive} \n";
        }
              
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListModule.Models
{
   
    public class Jedi
    {
      public string Name { get; set; }
      public string Height { get; set; }
      public string Mass { get; set; }
      public string Hair_Color { get; set; }
      public string Skin_Color { get; set; }
      public string Eye_Color { get; set; }
      public string Birth_Year { get; set; }
      public string Gender { get; set; }
      public string Homeworld { get; set; }
      public int ID { get; set; }


      public static Jedi NewJedi()
      {
         Jedi jedi = new Jedi
         {
            Name = "New Jedi",
            Height = "5ft2",
            Mass = "200lbs",
            Hair_Color = "Brown",
            Skin_Color = "Light",
            Eye_Color = "Blue",
            Birth_Year = "1993",
            Gender = "Female",
            Homeworld = "Earth",
            ID = 69
         };

         return jedi;
      }

   }

}

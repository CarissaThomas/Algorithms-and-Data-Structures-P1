using System;
using System.ComponentModel;
using System.Threading.Tasks;
using AlgorithmsAndData;
using AlgorithmsAndData.JediAPI;
using AlgorithmsAndData.Models;
using Newtonsoft.Json.Linq;

namespace Algorithms_and_Data
{
   class Program
   {
      static void Main(string[] args)
      {

         Console.WriteLine("Enter in a Jedi ID:");
         double ID;

         if (double.TryParse(Console.ReadLine(), out ID))
         {
            try
            {
               Task<Jedi> jediReturn = JediAPI.GetJedis(ID);

               jediReturn.Wait();

               Jedi jediComplete = jediReturn.Result;


               foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(jediComplete))
               {
                  string name = descriptor.Name;
                  object value = descriptor.GetValue(jediComplete);
                  Console.WriteLine("{0}={1}", name, value);
               }
               Console.WriteLine("Thats your one free jedi for the day human");
               Console.ReadLine();

            }

            catch (Exception ex)  //Exceptions here or in the function will be caught here
            {
               Console.WriteLine("Exception: " + ex.Message);
            }

         }
         else
         {
            Console.WriteLine("Enter in an ID you meatbag!");
         }


      }
   }
}

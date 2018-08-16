using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using AlgorithmsAndData;
using AlgorithmsAndData.JediAPI;
using AlgorithmsAndData.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Algorithms_and_Data
{
   class Program
   {
      static void Main(string[] args)
      {
         double ID;
         string response;


         Console.WriteLine("Do you want all the jedis or just one?  Type all or one.");
         response = Console.ReadLine();
            if (response == "all")
         {
            try
            {
               Task<List<Jedi>> jediListReturn = JediAPI.GetAllJedis();

               jediListReturn.Wait();

               List<Jedi> jediListComplete = jediListReturn.Result;

               jediListComplete.ForEach(item => Console.Write(JsonConvert.SerializeObject(item) + Environment.NewLine));


               Console.WriteLine("Noderize Jedis:");

               NodeChain.Noderize(jediListComplete);//Call the node example with jedis from API

               Console.ReadLine();

            }

            catch (Exception ex)  //Exceptions here or in the function will be caught here
            {
               Console.WriteLine("Exception: " + ex.Message);
            }

         }
         else if (response == "one")
         {
            Console.WriteLine("Enter in a Jedi ID:");

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
          else 
         {
            Console.WriteLine("I said enter A or O meatbag!");
         }

         


      }
   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using LinkedListModule.LinkedList;
using LinkedListModule.JediAPI;
using LinkedListModule.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LinkedListModule;
using JediConsole;

namespace Algorithms_and_Data
{
   class Program
   {
      static void Main(string[] args)
      {
         double ID;
         string response;


         Console.WriteLine("Hit enter to begin");
         response = Console.ReadLine();
         try
         {
            Task<List<Jedi>> jediListReturn = JediAPI.GetAllJedis();

            jediListReturn.Wait();

            List<Jedi> jediListComplete = jediListReturn.Result;

            jediListComplete.ForEach(item => Console.Write(JsonConvert.SerializeObject(item) + Environment.NewLine));

            Console.WriteLine("Here are your star wars characters, please press enter");

            Console.ReadLine();

            Console.WriteLine("Please select which module you would like displayed with these characters:");
            Console.WriteLine("Type one of the following: nodes, linked list, stack, queue, binary tree, hash table");

            switch (Console.ReadLine())
            {
               case "linked list":
                  Instruction.SetLinkedList(jediListComplete);
                  break;
               case "stack":
                  Instruction.SetStackArray(jediListComplete);
                  break;
               case "nodes":
                  NodeChain.Noderize(jediListComplete);
                  break;
               case "queue":
                  Instruction.SetQueue(jediListComplete);
                  break;
               case "binary tree":
                  Instruction.SetBinaryTree(jediListComplete);
                  break;
               case "hash table":
                  Instruction.SetHashTable(jediListComplete);
                  break;
               default:
                  Console.WriteLine("Please select from the list above");
                  break;
            }


         }

         catch (Exception ex)  //Exceptions here or in the function will be caught here
         {
            Console.WriteLine("Exception: " + ex.Message);
         }

      }

     


   }
}

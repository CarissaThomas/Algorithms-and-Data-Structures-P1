using LinkedListModule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinkedListModule//Chain together Star Wars characters by ID I generate 
{
   public class JediNodes
   {
      public String Value { get; set; }
      public JediNodes Next { get; set; }
   }

   public class NodeChain
   {
      public static void Noderize(List<Jedi> jediListComplete)
      {

         JediNodes first = new JediNodes { Value = jediListComplete.Where(x => x.ID == 3).Select(x => x.Name).FirstOrDefault() };

         JediNodes middle = new JediNodes { Value = jediListComplete.Where(x => x.ID == 5).Select(x => x.Name).FirstOrDefault() };

         first.Next = middle;

         JediNodes last = new JediNodes { Value = jediListComplete.Where(x => x.ID == 7).Select(x => x.Name).FirstOrDefault() };

         middle.Next = last;

         PrintList(first);
   }


      public static void PrintList(JediNodes node)
      {

         while (node != null)
         {
            Console.WriteLine(JsonConvert.SerializeObject(node) + Environment.NewLine);

            node = node.Next;
         }
         Console.ReadLine();
      }
   }

   

}

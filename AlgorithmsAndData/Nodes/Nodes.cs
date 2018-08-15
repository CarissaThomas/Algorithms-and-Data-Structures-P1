using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndData//Chain together Star Wars characters by ID I generate 
{
   public class Nodes
   {
      public int Value { get; set; }
      public Nodes Next { get; set; }
   }

   public class NodeChain
   {
      public static void Noderize()
      {
         Nodes first = new Nodes { Value = 3 };

         Nodes middle = new Nodes { Value = 5 };

         first.Next = middle;

         Nodes last = new Nodes { Value = 7 };

         middle.Next = last;

         PrintList(first);
   }


      public static void PrintList(Nodes node)
      {
         while (node != null)
         {
            Console.WriteLine(node.Value);
            node = node.Next;
         }
         Console.ReadLine();
      }
   }

   

}

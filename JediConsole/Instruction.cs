using BinaryTree;
using LinkedListModule.LinkedList;
using LinkedListModule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediConsole
{
    class Instruction : LinkedListModule.LinkedList.LinkedList<Jedi>
   {



      public static void SetLinkedList(List<Jedi> jediListComplete)
      {
         jediListComplete.ForEach(item => Console.Write(JsonConvert.SerializeObject(item) + Environment.NewLine));
         Console.WriteLine("Press enter");
         Console.WriteLine("Type which Linked List function you would like to see: add, remove first, or remove last");

         var JediLinkedList = new LinkedListModule.LinkedList.LinkedList<Jedi>();
         jediListComplete.ForEach(item => JediLinkedList.Add(item));

         switch (Console.ReadLine())
         {
            case "add":
               Jedi newJedi = Jedi.NewJedi();
               Console.WriteLine("New jedi you are adding " + newJedi);
               JediLinkedList.Add(newJedi);
               PrintList(JediLinkedList);
               Console.ReadLine();
               break;

            case "remove first":
               JediLinkedList.RemoveFirst();
               PrintList(JediLinkedList);
               Console.ReadLine();
               break;

            case "remove last":
               JediLinkedList.RemoveLast();
               PrintList(JediLinkedList);
               Console.ReadLine();
               break;
            default:
               break;
         }
      }

      public static void SetStackArray(List<Jedi> jediListComplete)
      {
         var JediLinkedList = new Stack.Array.Stack<Jedi>();

         Console.WriteLine("Press enter");
         Console.WriteLine("Type which Linked List function you would like to see: push, pop, or peek");

         jediListComplete.ForEach(item =>  JediLinkedList.Push(item));
         JediLinkedList._items = jediListComplete.ToArray();

         switch (Console.ReadLine())
         {
            case "Push":
               Jedi newJedi = Jedi.NewJedi();
               Console.WriteLine("New jedi you are adding " + newJedi);
               JediLinkedList.Push(newJedi);
               Console.ReadLine();
               break;

            case "Pop":
               JediLinkedList.Pop();
               PrintList(JediLinkedList);
               Console.ReadLine();
               break;

            case "Peek":
               JediLinkedList.Peek();
               PrintList(JediLinkedList);
               Console.ReadLine();
               break;
            default:
               break;
         }
      }

      public static void SetQueue(List<Jedi> jediListComplete)
      {
         Console.WriteLine("Press enter");
         Console.WriteLine("Type which Queue function you would like to see: enqueue");

         var QueueClass = new Queue.List.Queue<int>();//New Queue class

         var JediIDList = jediListComplete.Select(x => x.ID);

         switch (Console.ReadLine())
         {
            case "enqueue":
               Jedi newJedi = Jedi.NewJedi();
               QueueClass.Enqueue(newJedi.ID);
               PrintList(JediIDList);
               Console.ReadLine();
               break;
            default:
               break;
         }
      }

      public static void SetBinaryTree(List<Jedi> jediListComplete)
      {
         Console.WriteLine("Press enter");
         Console.WriteLine("Type which binary tree function you would like to see: add");

         var BinaryClass = new BinaryTree<int>();

         var JediIDList = jediListComplete.Select(x => x.ID).ToArray();

         switch (Console.ReadLine())
         {
            case "add":
               Jedi newJedi = Jedi.NewJedi();
               BinaryClass.Add(newJedi.ID);
               PrintList(JediIDList);
               Console.ReadLine();
               break;
            default:
               break;
         }
      }


      static void PrintList<T>(IEnumerable<T> items)
      {
         var props = typeof(T).GetProperties();

         foreach (var prop in props)
         {
            Console.Write("{0}\t", prop.Name);
         }
         Console.WriteLine();

         foreach (var item in items)
         {
            foreach (var prop in props)
            {
               Console.Write("{0}\t", prop.GetValue(item, null));
            }
            Console.WriteLine();
         }
      }


   }
}

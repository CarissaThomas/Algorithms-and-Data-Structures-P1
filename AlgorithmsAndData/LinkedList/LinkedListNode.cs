using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndData.LinkedList
{
   //Single chain of nodes 
   //Head pointer
   //Tail pointer
   //Provide operations that allow the list to be managed 

   public class LinkedListNode<Jedi>
    {


      public LinkedListNode(Jedi value)//creates a node with a predetermined value 
      {
         Value = value;
      }


      public Jedi Value { get; set; }


      public LinkedListNode<Jedi> Next { get; set; }

   }

   
}

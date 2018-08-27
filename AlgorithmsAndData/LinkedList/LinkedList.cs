using AlgorithmsAndData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndData.LinkedList
{
    public class LinkedList<Jedi> : ICollection<Jedi>
    {

      public LinkedListNode<Jedi> Head//First node in the list
      {
         get;
         private set;
      }

      public LinkedListNode<Jedi> Tail//Last node in the list 
      {
         get;
         private set;//The list is managing this and nothing else 
      }


      #region Add
      /// <summary>
      /// Adds the specified value to the start of the linked list
      /// </summary>
      /// <param name="value">The value to add to the start of the list</param>
      public void AddFirst(Jedi value)
      {
         AddFirst(new LinkedListNode<Jedi>(value));
      }


      public void AddFirst(LinkedListNode<Jedi> jedi)
      {
         LinkedListNode<Jedi> temp = Head;//save the head 


         Head = jedi;//Point head to new node 

         Head.Next = temp;//Insert rest of list behind the head 

         Count++;

         if (Count == 1)
         {
            Tail = Head;//If there is only one node in the list it is both the head and the tail 
         }

      }

      public void AddLast(LinkedListNode<Jedi> jedi)
      {

         if (Count == 0)//If the list is empty the head is what we are adding
         {
            Head = jedi;
         }
         else
         {
            Tail.Next = jedi;//not empty, we stick the item on the end of the list
         }

         Tail = jedi;
         Count++;
      }

      #endregion


      #region Remove

      public void RemoveLast()
      {
         if (Count != 0)//if the list is not empty 
         {
            if (Count == 1)//If there is only one node we remove it
            {
               Head = null;
               Tail = null;
            }
            else
            {
               LinkedListNode<Jedi> current = Head;
               while (current.Next != Tail)//while we havent selected current.next as the tail 
               {
                  current = current.Next;//Crawling through the list until we hit the tail 
               }

               current.Next = null;//Once we hit the last node, it will have no next 
               Tail = current;//The tail is now where the while loop was equal to the tail
            }

            Count--;//decrement count, once it hits zero we stop running this  
         }
      }

      public void RemoveFirst()
      {
         if (Count != 0)//if the list is not empty 
         {
            Head = Head.Next;//Assign the new head to the next value
            Count--;//Decrement the overall list length

            if (Count == 0)//If the list is now empty 
            {
               Tail = null;//Remove the tail
            }
         }
      }

      #endregion


      #region ICollection


      /// <summary>
      /// The number of items currently in the list
      /// </summary>
      public int Count
      {
         get;
         private set;
      }

      /// <summary>
      /// Adds the specified value to the front of the list
      /// </summary>
      /// <param name="item">The value to add</param>
      public void Add(Jedi item)
      {
         AddFirst(item);
      }

      /// <summary>
      /// Returns true if the list contains the specified item,
      /// false otherwise.
      /// </summary>
      /// <param name="item">The item to search for</param>
      /// <returns>True if the item is found, false otherwise.</returns>
      public bool Contains(Jedi item)
      {
         LinkedListNode<Jedi> current = Head;
         while (current != null)
         {
            if (current.Value.Equals(item))
            {
               return true;
            }

            current = current.Next;
         }

         return false;
      }

      /// <summary>
      /// Copies the node values into the specified array.
      /// </summary>
      /// <param name="array">The array to copy the linked list values to</param>
      /// <param name="arrayIndex">The index in the array to start copying at</param>
      public void CopyTo(Jedi[] array, int arrayIndex)
      {
         LinkedListNode<Jedi> current = Head;
         while (current != null)
         {
            array[arrayIndex++] = current.Value;
            current = current.Next;
         }
      }

      /// <summary>
      /// True if the collection is readonly, false otherwise.
      /// </summary>
      public bool IsReadOnly
      {
         get
         {
            return false;
         }
      }

      /// <summary>
      /// Removes the first occurance of the item from the list (searching
      /// from Head to Tail).
      /// </summary>
      /// <param name="item">The item to remove</param>
      /// <returns>True if the item was found and removed, false otherwise</returns>
      public bool Remove(Jedi item)
      {
         LinkedListNode<Jedi> previous = null;
         LinkedListNode<Jedi> current = Head;

         // 1: Empty list - do nothing
         // 2: Single node: (previous is null)
         // 3: Many nodes
         //    a: node to remove is the first node
         //    b: node to remove is the middle or last

         while (current != null)//we havent hit the end of the list 
         {
            if (current.Value.Equals(item))//does current value equal the one we are looking for 
            {
               // it's a node in the middle or end
               if (previous != null)//Not first node in list 
               {
                  // Case 3b

                  // Before: Head -> 3 -> 5 -> null
                  // After:  Head -> 3 ------> null
                  previous.Next = current.Next;

                  // it was the end - so update Tail
                  if (current.Next == null)
                  {
                     Tail = previous;
                  }

                  Count--;
               }
               else
               {
                  // Case 2 or 3a
                  RemoveFirst();//If we found the node we were looking for right away, its first in the list 
               }

               return true;
            }

            previous = current;//previous is our current, 3
            current = current.Next;//Current is pushed to the next, 5
         }

         return false;
      }

      /// <summary>
      /// Enumerates over the linked list values from Head to Tail
      /// </summary>
      /// <returns>A Head to Tail enumerator</returns>
      System.Collections.Generic.IEnumerator<Jedi> System.Collections.Generic.IEnumerable<Jedi>.GetEnumerator()
      {
         LinkedListNode<Jedi> current = Head;
         while (current != null)
         {
            yield return current.Value;
            current = current.Next;
         }
      }

      /// <summary>
      /// Enumerates over the linked list values from Head to Tail
      /// </summary>
      /// <returns>A Head to Tail enumerator</returns>
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return ((System.Collections.Generic.IEnumerable<Jedi>)this).GetEnumerator();
      }

      /// <summary>
      /// Removes all the nodes from the list
      /// </summary>
      public void Clear()
      {
         Head = null;
         Tail = null;
         Count = 0;
      }


      #endregion

   }
}
using System;

namespace Stack.Array
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as an array.
    /// </summary>
    /// <typeparam name="Jedi">The type of item contained in the stack</typeparam>
    public class Stack<Jedi> : System.Collections.Generic.IEnumerable<Jedi>
    {
        // The array of items contained in the stack.  Initialized to 0 length,
        // will grow as needed during Push
        public Jedi[] _items = new Jedi[0];

        // The current number of items in the stack.
        int _size;

        /// <summary>
        /// Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(Jedi item)
        {
            // _size = 0 ... first push
            // _size == length ... growth boundary
            if (_size == _items.Length)
            {
                // initial size of 4, otherwise double the current length
                int newLength = _size == 0 ? 4 : _size * 2;

                // allocate, copy and assign the new array
                Jedi[] newArray = new Jedi[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            // add the item to the stack array and increase the size
            _items[_size] = item;
            _size++;
        }

      /// <summary>
      /// Removes and returns the top item from the stack
      /// </summary>
      /// <returns>The top-most item in the stack</returns>
      public Jedi Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            _size--;
            return _items[_size];
        }

        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public Jedi Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items[_size - 1];
        }

        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            _size = 0;
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public System.Collections.Generic.IEnumerator<Jedi> GetEnumerator()
        {
            for (int i = _size-1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

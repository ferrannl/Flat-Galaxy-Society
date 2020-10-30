using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Utils.DataStructures
{
    public class DropOutStack<T>
    {
        private T[] items;
        private int count;
        private int top = 0;
        public DropOutStack(int capacity)
        {
            items = new T[capacity];
        }

        public void Push(T item)
        {
            items[top] = item;
            top = (top + 1) % items.Length;
            count++;
        }
        public T Pop()
        {
            if (count <= 0)
            {
                return default(T);
            }
            top = (items.Length + top - 1) % items.Length;
            count--;
            return items[top];
        }

        public int Count()
        {
            return count;
        }
    }
}

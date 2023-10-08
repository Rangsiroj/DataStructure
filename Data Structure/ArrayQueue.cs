using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class ArrayQueue : Queue
    {
        private object[] data;
        private int SIZE;
        private int cap;
        private int firstindex;

        public ArrayQueue(int cap) {}
        public bool isEmpty() { return SIZE == 0; }
        public int size() { return SIZE;}
        public void enqueue0(object e) {}
        public void enqueue(object e) 
        {
            ensureCapacity();
            int k = (firstindex + SIZE)% data.Length; firstindex = k;
            data[k] = e;
            SIZE++;
        }
        private void ensureCapacity() 
        {
            object[] tempdata;
            if (SIZE + 1 > data.Length)
                //Increase Capacity
                tempdata = new object[2 * data.Length];
            else if (data.Length > cap && data.Length > 2 * SIZE)
                //Decrease Capacity
                tempdata = new object[data.Length / 2 + 1];
            else return;
            for (int i = 0; i < SIZE; i++)
                tempdata[i] = data[i];  
            firstindex = 0;
            data = tempdata;
        }

        public object dequeue()
        {
            object e = peek();
            data[firstindex] = null;
            firstindex = (firstindex + 1)% data.Length;
            SIZE--;
            return e;
        }

        public object peek()
        {
            if(isEmpty())
                throw new System.MissingMemberException();
            return data[firstindex];    
        }
    }
}

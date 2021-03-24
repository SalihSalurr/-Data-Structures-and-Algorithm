using System;
using System.Collections.Generic;
using System.Text;

namespace Queue_And_Stacks
{
    class Stacks
    {
        int[] array;
        int size;
        int first;

        public Stacks(int size)
        {
            array = new int[size];
            first = -1;
            this.size = size;
        }

        public void Push(int x)
        {
            if (!(first == size))
            {
                first++;
                array[first] = x;
            }
            else
            {
                Console.WriteLine("Kapasite Dolu");
            }
        }

        public int Pop()
        {
            if (first == -1)
            {
                Console.WriteLine("Eleman Yok");
                return -1;
            }
            else
            {
                int a = array[first];
                first--;
                return a;
            }
        }
    }
}

using System;

namespace Queue_And_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stacks st = new Stacks(5);
            st.Push(5);
            st.Push(10);
            st.Push(15);
            st.Push(20);

            Console.WriteLine(st.Pop());

            Queue lq = new Queue();
            lq.Enq += Queue_Enq;                            // Event çalışınca yani her eklemede Queue_Enq metodu çalışacak.
            lq.Deq += Queue_Deq;                            // Event çalışınca yani her çıkarmada Queue_Enq metodu çalışacak.

            lq.Enqueue(5);
            lq.Enqueue(10);
            lq.Enqueue(15);
            lq.Enqueue(20);
            lq.Dequeue();
        }
        private static void Queue_Enq(int key, int counter)
        {
            Console.WriteLine("Eklenen veri: " + key + " numarası " + counter);
        }
        private static void Queue_Deq(int key, int counter)
        {
            Console.WriteLine("Silinen veri: " + key + " numarası " + counter);
        }
    }
    }


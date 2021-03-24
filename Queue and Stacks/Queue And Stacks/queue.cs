using System;
using System.Collections.Generic;
using System.Text;

namespace Queue_And_Stacks
{
    class QueueNode                                                     // Kuyruk elemanlarını tutmak için node sınıfı tanımlıyoruz.
    {
        public int key;                                                 // Kuyruktaki her elemanın değeri ve kendisinden sonraki elemanın adresini tutacak değişkenler tanımlıyoruz.
        public QueueNode next;

        public QueueNode(int key)                                       // Kuyruğa eleman geldiğinde, gelen değeri keye eşitlerken nextini null yapıyoruz ki bir sonra gelen değere eşitleyebilelim.
        {
            this.key = key;
            this.next = null;
        }
    }

    class Queue
    {
        public int counter;
        public delegate void EnqEventHandler(int key, int c);            // Ekleme ve çıkarma için delegate tanımlanıyor.
        public delegate void DeqEventHandler(int key, int c);
        public event EnqEventHandler Enq;                                // Ekleme ve çıkarma için event tanımlıyoruz.
        public event DeqEventHandler Deq;

        public QueueNode front, rear;                                    // Kuyruğun başını ve sonunu tanımlıyoruz.

        public Queue()
        {
            this.front = this.rear = null;                             // Constructor metotta sınıf çağırıldığında başını ve sonunu null yaparak değer atanabilir hale getiriyoruz.
        }

        public void Enqueue(int key)                                   // Kuyruğa eleman ekleme
        {
            QueueNode temp = new QueueNode(key);

            if (this.rear == null)                                     // Sondaki eleman null ise yani hiç eleman eklenmediyse hem başı hem sonu gelen elemana ekliyoruz.
            {
                this.front = this.rear = temp;
            }
            this.rear.next = temp;                                     // Gelen elemanı kuyruğun sonuna ekliyor yeni kuyruğu gelen eleman yapıyoruz.
            this.rear = temp;
            Enq?.Invoke(key, ++counter);                               // Ekleme metodu çalışınca ekleme eventini tetikliyoruz.
        }

        public void Dequeue()                                          // Kuyruktan eleman çıkarma
        {
            if (this.front == null)
            {
                Console.WriteLine("Eleman Yok");
            }
            int a;
            a = front.key;
            QueueNode temp = this.front;                               // Kuyruğun başından elemanı çıkarıyor yeni başı bir sonraki eleman yapıyoruz.
            this.front = this.front.next;

            if (this.front == null)                                    // Yeni baş null ise kuyrukta null oluyor.
            {
                this.rear = null;
            }
            Deq?.Invoke(a, --counter);                                 // Çıkarma metodu çalışınca çıkarma eventini tetikliyoruz.
        }

    }
}

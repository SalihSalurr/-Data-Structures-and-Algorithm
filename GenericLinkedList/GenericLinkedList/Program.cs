using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace GenericLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericLinkedList<int> GL = new GenericLinkedList<int>();
            for (int i = 0; i < 9 ; i++)
            {
                GL.insert(i);
            }
            GL.Remove();
            GL.write();
        }
    }
    
    public class GenericLinkedList<T>
    {
        public Node head, tail;                  // Listenin başını ve sonunu tutacak Node tipinde değişken oluşturuluyor.

        public class Node                        // Listenin her bir elemanını tutmak için Node sınıfı oluşturuluyor.
        { 
            public T key;                        // Tutulacak elemanın değerini tutmak içim değişken oluşturuluyor.
            public Node next, prev;              // Elemanın kendisinden önce ve sonra elecek elemanın adresini tutması için Node tipinde değişken oluşturuluyor.

            public Node(T data)                  // Consturctor metot yardımı ile gelen veriyi atıyor ve node'un sonraki ve önceki adreslerini null yapyoruz ki
            {                                    // yeni node kelince adresini atayabilelim.
                key = data;
                next = null;
                prev = null;
            }
        }
        /*
        private Node Find(T value)
        {
            Type type = typeof(T);
            PropertyInfo property = null;
            Node temp = tail;
            foreach (var propertyInfo in type.GetProperties())
            {
                KeyAttribute[] keyAttributes = (keyAttribute[])propertyInfo.GetCustomAttributes(typeof(KeyAttribute), false);
            }
        } 
        */
        public void insert(T key)                  // Ekleme işlemi sondan yapılıyor.
        {
            Node node = new Node(key);             // Ekleyeceğimiz node'u oluşturuyoruz.

            if (head == null)                      // İlk eleman boş değilse devam ediyor, eğer boşsa hiç eleman eklenmemiştir. Gelen elemanı ilk eleman yapıyoruz.
            {
                head = tail = node;
            }
            node.prev = tail;                      // Bu ekleme işleminde gelen eleman listenin sonuna ekleniyor. gelen elemanın öncesini son eleman yapıyoruz.
            tail.next = node;                      // Son elemanın sonrakini gelen eleman yapıyoruz. Bu kısımda bağlama işlemi bitti.
            tail = node;                           // Gelen elemanı sona eklediğimiz için listenin yeni sonuda gelen eleman olması gerekiyor.
        }
        public void Remove()                       // Çıkarma işlemi sondan yapılıyor. 
        {
            if (head == null)                      // Eğer ilk eleman null ise hiç eleman yoktur.
                return;
            if(head!=tail)                         // İlk eleman son elemana eşit değilse en az iki eleman vardır. Çıkarma işlemi yapabiliriz.
            {
                tail = tail.prev;                  // Son elemanın öncesini kendisine eşitliyoruz ve sonrakini null yapıyoruz.
                tail.next = null;                  // Eleman bir süre sonra Garbge Collactor ile yok edilecektir.
            }
            else
            {
                head = tail = null;
            }
        }
        public void write()                        // Burada da listeyi yazdırıyoruz. Eleman null'a eşit olana kadar yazdırıyor bir sonraki elemana geçiyorruz.
        {
            Node wNode = head;
            while (wNode != null)
            {
                Console.WriteLine(wNode.key + " ");
                wNode = wNode.next;
            }
        }
    }
}

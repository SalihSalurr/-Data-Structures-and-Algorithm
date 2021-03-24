using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList List = new LinkedList();
            List.insert(5);
            List.insert(6);
            List.insert(8);
            List.insert(15);
            List.insert(21);
            List.Remove();
            List.insertIN(6, 18);
            List.write();


        }
        class LinkedList
        {
            public Node head, tail;                        // Listenin başını ve sonunu tutacak Node tipinde değişken oluşturuluyor.

            public class Node                              // Listenin her bir elemanını tutmak için Node sınıfı oluşturuluyor.
            {
                public int key;                            // Tutulacak elemanın değerini tutmak içim değişken oluşturuluyor.
                public Node next, prev;                    // Elemanın kendisinden önce ve sonra elecek elemanın adresini tutması için Node tipinde değişken oluşturuluyor.

                public Node(int data)                      // Consturctor metot yardımı ile gelen veriyi atıyor ve node'un sonraki ve önceki adreslerini null yapyoruz ki
                {                                          // yeni node kelince adresini atayabilelim.
                    key = data;
                    next = null;
                    prev = null;
                }
            }

            public void insert(int key)                    // Ekleme işlemi sondan yapılıyor.
            {
                Node node = new Node(key);                 // Ekleyeceğimiz node'u oluşturuyoruz.

                if (head == null)                          // İlk eleman boş değilse devam ediyor, eğer boşsa hiç eleman eklenmemiştir. Gelen elemanı ilk eleman yapıyoruz.
                {
                    head = tail = node;
                }

                node.prev = tail;                          // Bu ekleme işleminde gelen eleman listenin sonuna ekleniyor. gelen elemanın öncesini son eleman yapıyoruz.
                tail.next = node;                          // Son elemanın sonrakini gelen eleman yapıyoruz. Bu kısımda bağlama işlemi bitti.
                tail = node;                               // Gelen elemanı sona eklediğimiz için listenin yeni sonuda gelen eleman olması gerekiyor.
            }
            public void insertIN(int number, int key)      // Araya ekleme işleminde hangi hangi elemandan sonra gelecekse onun değerini alıyoruz.
            {
                Node temp = head;                          // Elemanı bulma işlemi için gerekli node oluşturuyoruz.
                Node add = new Node(key);                  // Ekleyeceğimiz node'u oluşturuyoruz.
                while (temp.key == number)                 // Numarayı bulana kadar bir sonraki node'a geçiş yapıyoruz.
                {
                    temp = temp.next;
                }
                temp = temp.next;                          // Bulduğumuz Node istediğimizin bir önceki olacağı için bir sonraki node'a geçiş yapıyoruz.

                add.next = temp.next;                      // Ekleyeceğimiz node'un sonrakini, bulduğumuz node'un sonrakine eşitliyoruz.
                temp.next.prev = add;                      // Bulduğumuz node'dan sonra gelen node'un önceki elemanını ekleyeceğimiz elemana eşitliyoruz.
                add.prev = temp;                           // Ekleyeceğimiz node'un öncesini, bulduğumuz node yapıyoruz.
                temp.next = add;                           // Son olarak bulduğumuz node'un sonrakini ekleyeceğimiz node yapıyoruz ve tüm bağlantılar tamamlanmış oluyor.
            }                                              // Bu sıra önem arz ediyor. Eğer yanlış sıra ile yaparsanız Node'lardan biri yanlış adres ve ya null gösterbilirç
            public void Remove()                           // Çıkarma işlemi sondan yapılıyor. 
            {
                if (head == null)                          // Eğer ilk eleman null ise hiç eleman yoktur.
                    return;
                if (head != tail)                          // İlk eleman son elemana eşit değilse en az iki eleman vardır. Çıkarma işlemi yapabiliriz.
                {
                    tail = tail.prev;                      // Son elemanın öncesini kendisine eşitliyoruz ve sonrakini null yapıyoruz. 
                    tail.next = null;                      // Eleman bir süre sonra Garbge Collactor ile yok edilecektir.
                }
                else
                {
                    head = tail = null;                    // Sadece bir eleman olma durumu.
                }

            }
            public void write()                            // Burada da listeyi yazdırıyoruz. Eleman null'a eşit olana kadar yazdırıyor bir sonraki elemana geçiyorruz. 
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
}

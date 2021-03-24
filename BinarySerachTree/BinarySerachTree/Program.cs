using System;

namespace BinarySerachTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree b = new BinarySearchTree();
            b.insert(40);
            b.insert(15);
            b.insert(7);
            b.insert(18);
            b.insert(30);
            b.insert(25);
            b.insert(35);

            b.inorderTree(b.ReturnRoot());
        }
    }
    class BinarySearchTree
    {
        public class Node                                           // Node oluşturuluyor.
        {                                                                  
            public int key;                                                
            public Node left, right;

            public Node(int key1)                                   // Node sınıfı çağırıldğında constructor metod çalışarak key değeri atanacak.
            {
                key = key1;                                          
                left = right = null;                                // left ve right null oluyor ki yeni node yolunu eşitlerken problem çıkmasın ve parent child yapısı olsun.
            }
        }
        

        Node root;                                                  // Ağacın kökünü oluşturuyoruz.
        
        public BinarySearchTree()
        {
            root = null;                                            // BinarySearchTree sınıfının constructor metodunda root null değerine eşitleniyor ki değer geldiğinde eşitleyebilelim.
        }

        public void insert(int key)                                 // Aşağıdaki Node metoduna diğer sınıflardan ulaşabimek tanımlanıyor.
        {
            root = insertTree(root, key);
            Console.WriteLine("***"+root.key);                      // Eğer henüz root oluşturulmadıysa insertTree metodundan gelecek değer root olarak atanıyor.
        }

        Node insertTree(Node root,int key)                          // insert metodu her çağırldığında gelen key değeri ve root gönderiliyor. İlk gönderilen root her zaman ana root oluyor.
        {
            if (root == null)                          
            {
                root = new Node(key);                               // Eğer Root değeri yoksa, root yeni nNde'a key gönderilerek Node eşitleniyor.
                return root;
            }
            else
            {
                if (key < root.key)                                 // Root boş değilse gelen değer büyükse sağ çocuğuna küçükse sol çocuğuna bakılacak şekilde ilerleniyor.
                    root.left = insertTree(root.left, key);         // Burada anlaşılması gereken nokta Recursive metot çağırıldığında yeni root gönderdiğimiz root.left ve ya
                else if (key > root.key)                            // root.right oluyor. Bu rootlarda ilerleyerek uygun ve boş yer geldiğinde gelen key değeri yukarıdaki if koşulunda
                    root.right = insertTree(root.right, key);       // Node oluşturularak yerine yerleştiriliyor. 
            }
            return root;
            
        }
        public Node ReturnRoot()                                    // inorder ile yazdırmak için root göderilmesi gerek. Diğer classlardan gönderebilmek için tanımlıyoruz.
        {
            return root;
        }
        public void inorderTree(Node root)                          // inorder yöntemi ile ağaç yapısındaki elemanları yazdırıyoruz
        {
            if (root != null)
            {
                inorderTree(root.left);
                Console.WriteLine(root.key);                        //Yine recursive metot yardımı ile node içerisindeki önce en sol ve soldan sağa yani küçükten büyüğe 
                inorderTree(root.right);                            // olacak şekide yazdırılıyor.
            }
        }
    }
}

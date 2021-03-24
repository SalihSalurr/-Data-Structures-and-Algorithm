using System;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            tree.root = tree.insert(tree.root, 12);
            tree.root = tree.insert(tree.root, 8);
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 25);
            tree.root = tree.insert(tree.root, 18);
            tree.root = tree.insert(tree.root, 7);
            tree.inorderTree(tree.root);
        }
    }
    class Node                                         // Ağacın her bir elemanı için node sınfını kullanacağız.
    {
        public int key, h;                              // Her elemanın değeri için key ve ağacın derinliği için h değişkeni oluşturuluyor.
        public Node left, right;                        // Her nodun bir sağ bir de sol çocuğunu göstermek için Node tipinde left ve right oluşturuyoruz.

        public Node(int data)                           // constructor metot ile değer geldiğinde değeri key değişkenine, derinliği de bire eşitliyoruz. Her node 1 derinlik oluşturur.
        {
            key = data;
            h = 1;
        }
    }
    class AVLTree
    {
        public Node root;                              // Ağacın kökünü oluşturduk.
        int height(Node N)                            // Ağacın hem balance yani dengesine bakmak hem de en uzun derinliği bulmak için height metodu oluşturuldu.
        {
            if (N == null)
                return 0;

            return N.h;
        }

        int max(int a, int b)
        {
            return (a > b) ? a : b;                    // Gelen ağaç derinliklerinden büyük olanı döndürmek için oluşturulan metod.
        }

        Node rightRotate(Node r)                       // Sağa öteleme metodu
        {
            Node l = r.left;                           // Oluşturduğumu l node gelen metodun sol çocuğuna eşitliyoruz
            Node c = l.right;                          // Oluşturduğumuz c node gelen node'un sol çocuğunun sağ çocuğuna eşitliyoruz. 

            l.right = r;                               // Öteleme hareketi burada başlıyor. Gelen node'un sol çocuğunun sağ çocuğunu gelen node'a eşitliyoruz.  
            r.left = c;                                // Sol çocuğuda, kendisinin sol çocuğunu sağına eşitliyoruz. Bu sayede gelen node için düşünürsek yeni root l  oluyor. 
                                                       // Onun sağ çocuğu gelen node onun da sol çocuğu gelen node'un sol çocuğunun sağ çocuğu oluyor. 
            r.h = max(height(r.left), height(r.right)) + 1;         // Öteleme işleminden sonra yeni derinliklere bakılıyor. 
            l.h = max(height(l.left), height(l.right)) + 1;

            return l;
        }

        Node leftRotate(Node l)                         // Sola öteleme de sağa ötelemenin tam tersi yönlerde olacak şekilde.  
        {
            Node r = l.right;
            Node c = r.left;

            r.left = l;
            l.right = c;

            l.h = max(height(l.left), height(l.right)) + 1;
            r.h = max(height(r.left), height(r.right)) + 1;

            return r;
        }

        int balance(Node B)                            // Dengeye bakmak için sol derinlikten sağ derinliği çıkarıyoruz. Dengenin -2 < balance < 2 arasında olmalı. (-2 , 2 dahil değil)
        {
            if (B == null)
                return 0;

            return height(B.left) - height(B.right);
        }

        public Node insert(Node node, int key)                // Ekleme işlemi  
        {
            if (node == null)                                 // Doğru yer bulunduğunda eklenecek değerin node oluşturuluyor.
                return (new Node(key));

            if (key < node.key)                               //------------------------------
                node.left = insert(node.left, key);           // 
            else if (key > node.key)                          // Doğru yer Binary Search Tree gibi gelen değer kökten büyükse sağa küçükse sola gelecek çekilde bakılıyor.
                node.right = insert(node.right, key);         // Eğer sayı zaten ağaçta varsa geriye node döndürerek ekleme işlemi yapmıyor.
            else                                              //
                return node;                                  //------------------------------

            node.h = 1 + max(height(node.left),               // Ekleme işlemi yapıldıktan sonra yeni derinlikler bulunuyor. Dengeye bakmak için gerekiyor.
                            height(node.right));

            int b = balance(node);                            // Dengeye bakılıyor eğer aşağıdaki if koşullarından birine girerse, ağacın dengesiz olduğu 
                                                              // ve buna göre öteleme yapılacağı sonucunu çıkarabiliriz.
            if (b > 1 && key < node.left.key)                 // Balance 1 den büyükse (ağacın sola uzadığını gösterir) ve gelen değer sol çocuktan küçükse sağa öteleme işlemi yaparız.
                return rightRotate(node);

            if (b < -1 && key > node.right.key)               // 1 den büyük olma mantığının tam tersi.
                return leftRotate(node);

            if (b > 1 && key > node.left.key)                 // Burada ise oluşabilecek en karmaşık durum senaryosu. Denge birden büyük ve değer sol çocuktan büyükse tek öteleme yetmiyor.
            {
                node.left = leftRotate(node.left);            // Önce asıl node'un çocukları arasında öteleme yaparak yeni root olacak değeri bir üste taşıyoruz diyebiliriz. 
                return rightRotate(node);                     // Daha sonra ikinci bir öteleme hareketi ile root olacak değeri yerine götürmüş oluyoruz. 
            }

            if (b < -1 && key < node.right.key)               // Yukarıdaki mantığın tam tersi.
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return node;
        }

        public void inorderTree(Node root)                          // inorder yöntemi ile ağaç yapısındaki elemanları yazdırıyoruz
        {
            if (root != null)
            {
                Console.Write(root.key + " ");
                inorderTree(root.left);
                inorderTree(root.right);
            }
        }
    }
}



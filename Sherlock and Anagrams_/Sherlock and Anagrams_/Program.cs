using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;


namespace Sherlock_and_Anagrams_
{

    class Program
    {
        static int sherlockAndAnagrams(string s)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            int counter = 0;

            for (int i = 0; i < s.Length ; i++)
            {
                for (int j = 1 ; j <= s.Length - i; j++)
                {
                    string sub = s.Substring(i, j);                 //İç içe for döngüsünü kullanarak Substring metodu ile kelimenin tüm alt kümelerine ulaşabileceğiz
                    sub = String.Concat(sub.OrderBy(g => g));       //Concat metodu ile koleksiyon elemanlarını birleştirerek OrderBy ile de sıraladık 

                    if (d.ContainsKey(sub))                         //Eğer alt küme koleksiyonun içerisindeyse anahtarının değerini bir arttırdık
                    {
                        d[sub]++;
                    } 
                    else                                            //Alt küme koleksiyonda değilse de alt küme değeri ile 1 anahtarını vererek koleksiyona ekledik
                    {
                        d.Add(sub, 1);
                    }
                }
            }
            foreach (var item in d)                                 
            {
                    int count = item.Value;                         //Koleksiyon içerisindeki elemanın anahtar değerini count değişkenine eşitledik
                    counter +=(count * (count-1)) / 2;              //Buradaki asıl mantık koleksiyon içerisinde tekrarı olan elemanların anahtarına ulaşmak
            }
            return counter;
        }
        static void Main(string[] args)
        { 
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = sherlockAndAnagrams(s);

                Console.WriteLine(result);
            }

        }
    }
}

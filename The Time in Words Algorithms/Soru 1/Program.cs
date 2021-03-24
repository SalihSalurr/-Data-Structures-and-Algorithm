using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru_1
{
    class Program
    {
        // Complete the timeInWords function below.
        static string timeInWords(int h, int m)
        {
            string[] word = { "", "one", "two", "three", "four", 
                        "five", "six", "seven", "eight", "nine",
                        "ten" ,"eleven", "twelve", "thirteen",
                        "fourteen",  "quarter", "sixteen", "seventeen",
                        "eighteen", "nineteen", "twenty"};     //Gerekli olacak kelimeleri tutan dizi 
           if(m<30 && m!=15 && m!=0 )                          //Dakikanın 30'dan düşük, 15 ve 0'a eşit olmadığı koşul
            {
               if (m < 10)                                     //Dakikanın 10'dan küçük olduğu zaman sadece tek haneli sayıların olduğu koşul    
                 return word[m]+" minute past " + word[h];     //World dizisindeki dakikanın ve saatin denk geldiği indeksli elemanı geriye döndürüyor
               if( m >= 10 && m < 20 )                         //Bu koşulda 10 dahil 10 ile 20 arasındaki sayıların seçimi
                return word[m]+ " minutes past " + word[h];    // World dizisindeki dakikanın ve saatin denk geldiği indeksli elemanı geriye döndürüyor
                if (m >= 20)                                   //30'dan küçük olma koşulunun içerisinde 20 dahil olmak üzeri 20 ile 30 arasındaki sayılarım seçmi
                return word[20]+ " "+ word[m % 20] + " minutes past " + word[h]; /*Artık burada iki heceli sayılara geçtiğimiz için ilk olarak 20 yani
                                                                                  twelve daha sonra gelen dakikanın mod 20'ye göre olan indeksini
                alarak 2. heceyi elde ediyoruz*/
            }
            else if(m>30 && m != 45)
            {
                m = 60 - m;                                    //Yukarıdaki işlemlerden farklı olarak; gelen dakikayı 60'tan çıkarıyoruz ki yine ihtiyacımız olan  30'dan küçük sayılarla ulaşalım
                if (m < 10)
                    return word[m] + " minute to " + word[h+1];
                if (m >= 10 && m < 20)
                    return word[m] + " minutes to " + word[h+1];
                if (m >= 20)
                    return word[20] + " " + word[m % 20] + " minutes to " + word[h+1];
            }
            else if (m == 45)                                 //Çeyrek kala
            {
                return word[15] + " to " + word[h+1];         //Tanımladığımız dizideki quarter'ın indeksi
            }
            else if(m==15)                                    //Çeyrek geçe
            {
                return word[15] + " past " +
                    " " + word[h];
            }
            else if(m==0)                                     //Tam
            {
                return word[h] + " o' clock" ;
            } 
            else                                              //Buçuk
            {
                return "half past " + word[h];
            }
            return "";
        }

        static void Main(string[] args)
        {
            
            int h = Convert.ToInt32(Console.ReadLine());

            int m = Convert.ToInt32(Console.ReadLine());

            string result = timeInWords(h, m);

            Console.WriteLine(result);

        }
    }
}

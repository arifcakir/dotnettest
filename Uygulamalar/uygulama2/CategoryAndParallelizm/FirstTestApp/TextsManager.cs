using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FirstTestApp
{
    [Trait("Category","Texts Testleri")]
   public class TextsManager
    {

        public string Concatenate(string a, string b)
        {
                    return $"{a} {b}";
        }


        /// <summary>
        /// hangi durumlar için kod yazılmalı. coverage ne olmalı
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string Concatenate(int sayi1, int sayi2)
        {
            if (sayi1 < 10 || (sayi2 < 101 && sayi2 > 49) )
                return (sayi1 + sayi2).ToString();

            return $"{sayi1.ToString()} {sayi2.ToString()}";

        }

        public bool Search(string text1, string text2)
        {
            return text1.Contains(text2);
        }








    }
}

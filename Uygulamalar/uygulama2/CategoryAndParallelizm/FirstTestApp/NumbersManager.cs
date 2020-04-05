using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FirstTestApp
{

    /// <summary>
    /// bu class ı business layer olarak varsayınız.
    /// </summary>
    public class NumbersManager
    {


        /// <summary>
        /// TODO: Hangi testler yazılabilir?.
        /// bu kodların her birinde beklenmeyen hatalar oluşabilir
        /// bu durumda sizce kodlarda ne tür  değişiklikler uygun olacaktır.
        /// (hint: geri dönüş değerleri nasıl değiştirilebilir?)
        /// </summary>


        private readonly Dictionary<int,int> _numbers;


        public NumbersManager(Dictionary<int, int> numbers)
        {
            _numbers = numbers;
        }
        
        public bool AddItem(int i)
        {
            var b = addItem(i);
            return b;
        }

        public bool AddItem(string s)
        {
            var i = toInt(s);
            var b = addItem(i);
            return b;
        }

        public bool DeleteItem(int i)
        {
           var b= _numbers.Remove(i);
           return b;
        }

        public int FindItem(int i)
        {
            var fi = _numbers[i];
            return fi;
        }

        /// <summary>
        /// TODO: bu fonksiyonun testi nasıl olmalı?
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            var i = _numbers.Sum(d=>d.Value);
            return i;
        }

        [ExcludeFromCodeCoverage] //TODO : buraya dikkat
        private int toInt(string s)
        {
            var i = int.Parse(s);
            return i;
        }


        /// <summary>
        /// TODO: bu fonksiyonunn testi nasıl olmalı?
        /// TODO: bu fonksiyon kod kalitesi açısındanm nasıl yazılabilirdi?
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">rakam 1000 den büyük olamaz</exception>
        /// <returns></returns>
        [ExcludeFromCodeCoverage] //TODO : buraya dikkat
        private bool addItem(int i)
        {
            if (i > 1000)
                throw new ArgumentOutOfRangeException("i", "1000'den büyük değer girilemez");
            bool b = i < 101 && i >0;
            if (b==true)
            {
                _numbers.Add(i,i);
            }

            return b;
        }

    }
}

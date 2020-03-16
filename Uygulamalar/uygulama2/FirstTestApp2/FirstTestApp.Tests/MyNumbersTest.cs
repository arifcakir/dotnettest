using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;

/// <summary>
/// https://github.com/brendanconnolly/Xunit.Categories
/// attribute ların extend edilebilirliğine örnek olarak
/// https://bitwiseguy.wordpress.com/2015/11/23/creating-readable-xunit-test-method-names-automatically/
/// </summary>


namespace FirstTestApp.Tests
{
    [DisplayName("Numara Testleri")]
    [Trait("Category","Numara Testleri")]
    [Trait("Test Type ", "Unit Tests for NumbersManager")]
    [Collection("Numbers Collection")]
    public class MyNumbersTest : IDisposable
    {
        private readonly NumbersManager _myNumbersManager;
        private readonly Dictionary<int, int> _numbers;
        private readonly ITestOutputHelper output;
        private const int sleepTime = 2000;

        /// <summary>
        /// her bir test fonksiyonu için constructure çalışır ve dispğose ile dispose edilir.
        /// IDispose uygulanmmaış bile olsa default da xunit bu şekilde çalışır.
        /// Ancak 
        /// </summary>
        public  MyNumbersTest(ITestOutputHelper output)
        {
            _numbers = new Dictionary<int, int>();
            _myNumbersManager = new NumbersManager(_numbers);

        }

        public void Dispose()
        {
            _numbers.Clear();
        }


        [Fact(DisplayName = "1 ile 100 arasında rakam girilmesi testi")]
        public void rakam_1_le_100_arasinda_girildiginde_true_rakami_donmeli()
        {
            var b = _myNumbersManager.AddItem(1);
            
            Thread.Sleep(sleepTime);

            Assert.True(b);
        }

        [Theory(DisplayName = "1 den küçük 100 den büyük rakam girilmesi testi")]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]

        // [InlineData(2147483647)] //2_147_483_647 int32 max int değeri
        //TODO: bu test yapılmalı mıydı sizce?
        //(yapılcaksa eğer burada mı yapılmalı?)
        // bu değerler mi yapılmalı?
        public void rakam_1_le_100_arasinda_girilmediginde_false_donmeli(int i)
        {
            var b = _myNumbersManager.AddItem(i);
            
            Thread.Sleep(sleepTime);

            Assert.False(b); //Negatif sonuç testi.
        }

        [Theory(DisplayName = "1000 den büyük rakam girilmesi testi")]
        [InlineData(1001)]
        [InlineData(1002)]
        public void rakam_int32_max_degerinden_buyuk_girildiginde_hata_donmeli(int i)
        {
            Action act = () => _myNumbersManager.AddItem(i);
            
            Thread.Sleep(sleepTime);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        // TODO: sizce sadece true sonucunu beklemek yeterli mi?
        // true sonucunu beklmek yeterli değilse başka ne yapılabilir?
        [Fact(DisplayName = "Listeden rakam silinmesi testi")]
        public void listeden_rakam_silindiginde_true_donmeli()
        {
            bool b=false;
            
            Thread.Sleep(sleepTime);

            // TODO: sizce burası kod kalitesi açısından nasıl yazılmalıydı?
            if (_myNumbersManager.AddItem(5))
                b = _myNumbersManager.DeleteItem(5);

            Assert.True(b);

        }


        // TODO: sizce bu test yeterli mi?
        // TODO : (hint: geri dönüş değerleri nasıl değiştirilebilir?)
        [Fact(DisplayName = "Aranan rakamın dönmesi testi")]
        public void aranan_rakam_listede_varsa_rakamin_kendisi_donmeli()
        {
            int returningNum=0;
            Thread.Sleep(sleepTime);


            var b = _myNumbersManager.AddItem(6);

            if (b)
                returningNum = _myNumbersManager.FindItem(6);

            Assert.Equal(6, returningNum);

        }


        // TODO: sizce bu test yeterli mi?
        // TODO: beklediğimiz sonuç sadece değerin pozitif olması mı olmalı?
        [Fact(DisplayName = "Rakamların topnması tesi")]
        public void rakamlarin_toplami_pozitif_deger_olmali()
        {
            var result = _myNumbersManager.Sum();
            
            Thread.Sleep(sleepTime);

            Assert.True(result > -1);
        }


        [Fact(DisplayName = "String değerin rakam olası testi")]
        public void string_olarak_rakam_girildiginde_true_donmeli()
        {

            var b = _myNumbersManager.AddItem("1");
            
            Thread.Sleep(sleepTime);

            Assert.True(b);

        }

        [Fact(DisplayName = "String değerin rakam olmaması testi")]
        public void rakam_olmayan_string_deger_girildiginde_exception_donmeli()
        {

            Dictionary<int,int> dfd=new Dictionary<int, int>();
            
            Thread.Sleep(sleepTime);

            Action myAction = ()=> _myNumbersManager.AddItem("rt");
            
            Assert.Throws<FormatException>(myAction);

        }

       
    }
}

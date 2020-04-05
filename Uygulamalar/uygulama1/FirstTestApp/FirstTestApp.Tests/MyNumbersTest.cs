using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;
using Xunit.Sdk;


namespace FirstTestApp.Tests
{
    public class MyNumbersTest
    {
        private readonly MyNumberManager _myNumbersManager;
        public  MyNumbersTest()
        {
            var numbers = new Dictionary<int, int>();
            _myNumbersManager = new MyNumberManager(numbers);
        }

        [Fact]
        public void rakam_1_le_100_arasinda_girildiginde_true_donmeli()
        {
            var b = _myNumbersManager.AddItem(1);
            Assert.True(b);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]
        // [InlineData(2147483647)] //2_147_483_647 int32 max int değeri
        //TODO: bu test yapılmalı mıydı sizce?
        //(yapılcaksa eğer burada mı yapılmalı?)
        // bu değerlerle mi yapılmalı?
        public void rakam_1_le_100_arasinda_girilmediginde_false_donmeli(int i)
        {
            var b = _myNumbersManager.AddItem(i);
            Assert.False(b); //Negatif sonuç testi.
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        public void rakam_int32_max_degerinden_buyuk_girildiginde_hata_donmeli(int i)
        {
            Action act = () => _myNumbersManager.AddItem(i);
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        // TODO: sizce sadece true sonucunu beklemek yeterli mi?
        // true sonucunu beklmek yeterli değilse başka ne yapılabilir?
        [Fact]
        public void listeden_rakam_silindiginde_true_donmeli()
        {
            bool b=false;

            // TODO: sizce burası kod kalitesi açısından nasıl yazılmalıydı?
            if (_myNumbersManager.AddItem(5))
                b = _myNumbersManager.DeleteItem(5);

            Assert.True(b);

        }


        // TODO: sizce bu test yeterli mi?
        // TODO : (hint: geri dönüş değerleri nasıl değiştirilebilir?)
        [Fact]
        public void aranan_rakam_listede_varsa_rakamin_kendisi_donmeli()
        {
            int returningNum=0;

            var b = _myNumbersManager.AddItem(6);

            if (b)
                returningNum = _myNumbersManager.FindItem(6);

            Assert.Equal(6, returningNum);

        }


        // TODO: sizce bu test yeterli mi?
        // TODO: beklediğimiz sonuç sadece değerin pozitif olması mı olmalı?
        [Fact]
        public void rakamlarin_toplami_pozitif_deger_olmali()
        {
            var result = _myNumbersManager.Sum();
            Assert.True(result > -1);
        }


        [Fact]
        public void string_olarak_rakam_girildiginde_true_donmeli()
        {

            var b = _myNumbersManager.AddItem("1");
            
            Assert.True(b);

        }

        [Fact]
        public void rakam_olmayan_string_deger_girildiginde_exception_donmeli()
        {
            Action myAction = ()=> _myNumbersManager.AddItem("rt");
            Assert.Throws<FormatException>(myAction);

        }

    }
}

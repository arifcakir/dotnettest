using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace FirstTestApp.Tests
{

    [DisplayName("Text Testleri")]
    [Trait("Category","Text Testleri")]
    [Collection("Texts Collection")]
    public class TextsManagerTests
    {
        private readonly TextsManager _textsManager;
        private const int sleepTime = 2000;

        public TextsManagerTests()
        {
            _textsManager=new TextsManager();
        }

        [Theory(DisplayName = "İki string ifade girildiğinde boşluk bırakarak birleşmeli")]
        [InlineData("string 1", "string 2")]
        [InlineData("Long String 1", "Long String 2")] // TODO: burada Theory kullanmaya gerek var mı?
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void iki_string_ifade_girildiginde_bosluk_birakarak_birlesmeli(string a, string b)
        { 
          var result =  _textsManager.Concatenate(a, b);

          Thread.Sleep(sleepTime);

          Assert.Equal($"{a} {b}", result);
        }


        [Theory(DisplayName = "sayi1 10 dan sayıların rakam toplamı dönmeli")]
        [InlineData(9, 1)]
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void sayi1_degiskeni_10_dan_kucukse_sayilerin_rakam_toplami_donmeli(int sayi1, int sayi2)
        {
          var result= _textsManager.Concatenate(sayi1, sayi2);

          Thread.Sleep(sleepTime);

          Assert.Equal((sayi1 + sayi2).ToString(), result);
        }


        [Theory(DisplayName = "sayi2 50 ile 100 arasındaysa sayıların rakam toplamı dönmeli")]
        [InlineData(1, 51)]
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void sayi2_degiskeni_50_ile_100_arasindaysa_sayilarin_rakam_toplami_donmeli(int sayi1, int sayi2)
        {
            var result = _textsManager.Concatenate(sayi1, sayi2);

            Thread.Sleep(sleepTime);

            Assert.Equal((sayi1 + sayi2).ToString(), result);
        }


        [Theory(DisplayName = "sayi1 10 dan küçük değilse ve sayi2 50 ile 100 arasında değilse sayıların metinsel birleşimi donmeli")]
        [InlineData(11, 49)]
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void sayi1_10_dan_kucuk_degilse_ve_sayi2_50_100_arasinda_degilse_metinsel_birlesim_donmeli(int sayi1, int sayi2)
        {
            var result = _textsManager.Concatenate(sayi1, sayi2);

            Thread.Sleep(sleepTime);

            Assert.Equal($"{sayi1.ToString()} {sayi2.ToString()}", result);
        }


        [Theory(DisplayName = "text2 text1 in içinde varsa true donmeli")]
        [InlineData("text1 text2", "text2")]
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void text2_text2_nin_icinde_geciyorsa_true_donmeli(string text1, string text2)
        {
            var result = _textsManager.Search(text1, text2);

            Thread.Sleep(sleepTime);

            Assert.True(result);
        }

        [Theory(DisplayName = "text2 text1 in içinde yoksa false donmeli")]
        [InlineData("text1 text2", "text2")]
        [Trait("Test Type ", "Unit Tests for TextsManager")]
        public void text2_text2_nin_icinde_gecmiyorsa_false_donmeli(string text1, string text2)
        {
            var result = _textsManager.Search(text1, text2);

            Thread.Sleep(sleepTime);

            Assert.True(result);
        }


    }
}

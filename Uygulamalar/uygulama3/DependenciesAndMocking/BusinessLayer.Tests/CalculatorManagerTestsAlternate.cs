using System;
using DataAccessLayer;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BusinessLayer.Tests
{


    /// <summary>
    /// Alternatif bu çözümde FluentAssertion daha okunaklı Assert işlerimler için kullanıldı.
    /// NSubstitute ise mock lama işlmelerini daha oklunaklı ve kolay yapılabilir hale getirmek için kullanıldı
    /// </summary>


    [Trait("Category","Calculator Testi Alternate")]
    public class CalculatorManagerTestsAlternate
    {

        private ICalculatorManager _calculatorManager;
        private IMathRepository _mathRepository;
        public CalculatorManagerTestsAlternate()
        {
            _mathRepository = Substitute.For<IMathRepository>();

            _mathRepository.GetIntMax().Returns(Int32.MaxValue);
            _mathRepository.GetIntMin().Returns(Int32.MinValue);

            _calculatorManager =new CalculatorManager(_mathRepository);
        }

        [Theory(DisplayName = "Toplama Testi")]
        [InlineData(new int[] {1, 2, 3}, 6)]
        public void Rakamlar_toplandiginda_sonuc_beklnen_degere_esit_olmali(int[] numbers, int result)
        {
            //Arrange yok(!!!!!)
            // bu kısmın olmuyor olması bir problem değil ama code smell durumunun olma ihtimalini gösteriyor bize.
            // aslında ilgili fonksiyon hem ekleme hemde toplama işi yapıyor demektir. iki ayrı fonksiyon olasydı. arrange bölümünde ekleme yapılabilirdi.

            //Act
            var sum = _calculatorManager.Sum(numbers);

            result.Should().Be(result);
        }

        [Theory(DisplayName = "MinInt'e ekleme testi")]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(100)] //daha kaçtane sayı eklenebilir
        public void MinInt_e_rakam_eklendiginde_socuc_beklenen_degere_esit_olmalidir(int a)
        {
            //Arrange  yok

            //Act
            //bu test de calculator manager mathrepository mock u kullanmaktadır.
            var sum = _calculatorManager.AddToMinInt(a);

            //Assert
            Assert.Equal(int.MinValue + a, sum);
        }


        [Theory(DisplayName = "negatif sayı kontrol testi")]
        [InlineData(-1)]
        [InlineData(-1000)] // sadece tek test yeterli değil mi? doğru sonuç dönmeyecek test yapılabilir mi?
        public void Negatif_sayi_sorgulandiginda_sonuc_true_donmeli(int a)
        {
            //Arrange 
            _mathRepository.IsNegative(a).Returns(true);

            //Act
            //bu test de calculator manager mathrepository mock u kullanmaktadır.
            var result = _calculatorManager.IsNegative(a);

            //Assert
            result.Should().Be(true);
        }

        [Theory(DisplayName = "sayı kontrol testi")]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData("-1")]// sadece tek test yeterli değil mi? doğru sonuç dönmeyecek test yapılabilir mi?
        public void Numara_olarak_string_deger_girildiginde_beklenen_mesaj_donmeli(string a)
        {
            //Arrange 
            _mathRepository.IsNumber(a).Returns(true);

            //Act
            //bu test de calculator manager mathrepository mock u kullanmaktadır.
            var result = _calculatorManager.IsNumber(a);

            //Assert
            result.Should().Be(CoreLib.Constants.NumberMessage);
        }







    }
}

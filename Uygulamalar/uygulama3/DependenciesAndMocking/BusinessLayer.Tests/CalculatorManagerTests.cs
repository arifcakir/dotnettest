using System;
using DataAccessLayer;
using Moq;
using NSubstitute;
using Xunit;

namespace BusinessLayer.Tests
{
    [Trait("Category","Calculator Testi")]
    public class CalculatorManagerTests
    {

        private ICalculatorManager _calculatorManager;
        private Mock<IMathRepository> _mathRepositoryMock;
        public CalculatorManagerTests()
        {
                _mathRepositoryMock = new Mock<IMathRepository>();

                _mathRepositoryMock.Setup(t => t.GetIntMax().Returns(Int32.MaxValue));
                _mathRepositoryMock.Setup(f => f.GetIntMin().Returns(Int32.MinValue));

                _calculatorManager=new CalculatorManager(_mathRepositoryMock.Object);
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

            Assert.Equal(result,sum);
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
            _mathRepositoryMock.Setup(x => x.IsNegative(a).Returns(true));

            //Act
            //bu test de calculator manager mathrepository mock u kullanmaktadır.
            var result = _calculatorManager.IsNegative(a);

            //Assert
            Assert.Equal(true, result);
        }

        [Theory(DisplayName = "sayı kontrol testi")]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData("-1")]// sadece tek test yeterli değil mi? doğru sonuç dönmeyecek test yapılabilir mi?
        public void Numara_olarak_string_deger_girildiginde_beklenen_mesaj_donmeli(string a)
        {
            //Arrange 
            _mathRepositoryMock.Setup(x => x.IsNumber(a).Returns(true));

            //Act
            //bu test de calculator manager mathrepository mock u kullanmaktadır.
            var result = _calculatorManager.IsNumber(a);

            //Assert
            Assert.Equal(CoreLib.Constants.NumberMessage, result);
        }







    }
}

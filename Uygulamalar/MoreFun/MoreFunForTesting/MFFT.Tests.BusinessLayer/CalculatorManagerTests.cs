using System;
using MFFT.BusinessLayer;
using MFFT.DataLayer;
using Moq;
using Xunit;

namespace MFFT.Tests.BusinessLayer
{
    public class CalculatorManagerTestsMoreFun
    {



        private readonly ICalculatorManager _calculatorManager;
        private readonly Mock<IMathRepository> _mathRepositoryMock;
        public CalculatorManagerTestsMoreFun()
        {

            _mathRepositoryMock = new Mock<IMathRepository>();

            _mathRepositoryMock.Setup(repository => repository.GetIntMax()).Returns(Int32.MaxValue);
            _mathRepositoryMock.Setup(repository => repository.GetIntMin()).Returns(Int32.MinValue);

            _calculatorManager = new CalculatorManager(_mathRepositoryMock.Object);

        }

        [Theory(DisplayName = "Sum Test for (- -)")]
        [InlineData(new int[]{-1,-1}, -2)]
        [InlineData(new int[] { -10, -20 }, -30)]
        public void Iki_Negatif_Sayı_Toplandiginda_Sonuc_Negatif_Toplam_Olmali(int[] numbers, int expected)
        {
            var result = _calculatorManager.Sum(numbers);
            Assert.Equal(expected,result);
        }

        [Theory(DisplayName = "Sum Test for (+ -)")]
        [InlineData(new int[] { 2, -1 }, 1)]
        [InlineData(new int[] { 20, -10 }, 10)]
        public void Ilk_Sayi_Pozitif_Ve_Ikinci_Sayidan_Mutlak_Olarak_Buyukse_Toplam_Pozitif_Olmalidir(int[] numbers, int expected)
        {
            var result = _calculatorManager.Sum(numbers);
            Assert.Equal(expected, result);
        }


        [Theory(DisplayName = "Sum Test for (- +)")]
        [InlineData(new int[] { -2, 1 }, -1)]
        [InlineData(new int[] { -20, 10 }, -10)]
        public void Ilk_Sayi_Negatif_Ve_Ikinci_Sayidan_Mutlak_Olarak_Buyukse_Toplam_Negatif_Olmalidir(int[] numbers, int expected)
        {
            var result = _calculatorManager.Sum(numbers);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Sum Test for (- - + +)")]
        [InlineData(new int[] { -2, -2, 1, 1 }, -2)]
        [InlineData(new int[] { -20, -20, 10, 10 }, -20)]
        public void Negatif_Sayilarin_Toplami_Nutlak_Olarak_Pozitif_Sayailarin_Toplamindan_Buyuk_Olursa_Sonuc_Negatif_Olmalidir(int[] numbers, int expected)
        {
            var result = _calculatorManager.Sum(numbers);
            Assert.Equal(expected, result);
        }


        [Theory(DisplayName = "Sum Test for (+ + - -)")]
        [InlineData(new int[] { 2, 2, -1, -1 }, 2)]
        [InlineData(new int[] { 20, 20, -10, -10 }, 20)]
        public void Pozitif_Sayilarin_Toplami_Nutlak_Olarak_negatif_Sayailarin_Toplamindan_Buyuk_Olursa_Sonuc_Pozitif_Olmalidir(int[] numbers, int expected)
        {
            var result = _calculatorManager.Sum(numbers);
            Assert.Equal(expected, result);
        }

    }
}

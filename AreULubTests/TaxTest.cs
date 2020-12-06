using System;
using Xunit;
using AreULub.Models;
namespace AreULubTests
{
    public class TaxTest
    {
        [Fact]
        public void TaxCalculateTest()
        {
            //Arrange
            var taxForm = new TaxModel()
            {
                TotalBill = 1000,
                StatePercentageTax = 10
            };
            //Act
            var TaxResult = taxForm.Calculate();
            //Assert
            Assert.True(TaxResult == 1100);
        }
    }
}

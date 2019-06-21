using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftAidCalculator.Service;
using GiftAidCalculator.TestConsole.Service;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class GiftAidCalculatorTests
    {

        [TestCase(20, 10, 2.5, TestName = "Tax rate at 20% - Returns 20% of 10")]
        [TestCase(20, 13, 3.25, TestName = "Tax rate at 20% - Returns 20% of 13")]
        [TestCase(25, 10, 3.33, TestName = "Tax rate at 25% - Returns 25% of 10")]
        [TestCase(25, 13, 4.33, TestName = "Tax rate at 25% - Returns 25% of 13")]
        [TestCase(17.3, 53, 11.09, TestName = "Rounded to two places")]
        public void GetGiftAidAmount_ReturnsExpectedGiftAidAmount(decimal taxRate, decimal donationAmount, decimal expectedGiftAid)
        {
            var taxRateProvider = new Mock<ITaxRateProvider>();
            taxRateProvider.Setup(x => x.GetTaxRate()).Returns(taxRate);

            var giftAidCalculator = new DefaultGiftAidCalculator(taxRateProvider.Object);
            Assert.AreEqual(expectedGiftAid, giftAidCalculator.GetGiftAidAmount(donationAmount));
        }

        [TestCase(10, 0.5, TestName = "5% of 10")]
        [TestCase(13, 0.65, TestName = "5% of 13")]
        public void GetSupplementGiftAidAmount_RunningEvent_ReturnsFivePercent(decimal giftAidAmount, decimal expectedSupplementAmount)
        {
            var taxRateProvider = new Mock<ITaxRateProvider>();
            taxRateProvider.Setup(x => x.GetTaxRate()).Returns(0.2M);

            var giftAidCalculator = new DefaultGiftAidCalculator(taxRateProvider.Object);
            Assert.AreEqual(expectedSupplementAmount, giftAidCalculator.GetGiftAidSupplementAmount(giftAidAmount, DonationEventType.Running));
        }

        [TestCase(10, 0.3, TestName = "3% of 10")]
        [TestCase(13, 0.39, TestName = "3% of 13")]
        public void GetSupplementGiftAidAmount_SwimmingEvent_ReturnsFivePercent(decimal giftAidAmount, decimal expectedSupplementAmount)
        {
            var taxRateProvider = new Mock<ITaxRateProvider>();
            taxRateProvider.Setup(x => x.GetTaxRate()).Returns(0.2M);

            var giftAidCalculator = new DefaultGiftAidCalculator(taxRateProvider.Object);
            Assert.AreEqual(expectedSupplementAmount, giftAidCalculator.GetGiftAidSupplementAmount(giftAidAmount, DonationEventType.Swimming));
        }

        [TestCase(10, 0, TestName = "Should Return 0")]
        public void GetSupplementGiftAidAmount_DefaultEvent_ReturnsZero(decimal giftAidAmount, decimal expectedSupplementAmount)
        {
            var taxRateProvider = new Mock<ITaxRateProvider>();
            taxRateProvider.Setup(x => x.GetTaxRate()).Returns(0.2M);

            var giftAidCalculator = new DefaultGiftAidCalculator(taxRateProvider.Object);
            Assert.AreEqual(expectedSupplementAmount, giftAidCalculator.GetGiftAidSupplementAmount(giftAidAmount, DonationEventType.Default));
        }

        [TestCase(10, 0, TestName = "Should Return 0")]
        public void GetSupplementGiftAidAmount_UnknownEvent_ReturnsZero(decimal giftAidAmount, decimal expectedSupplementAmount)
        {
            var taxRateProvider = new Mock<ITaxRateProvider>();
            taxRateProvider.Setup(x => x.GetTaxRate()).Returns(0.2M);

            var giftAidCalculator = new DefaultGiftAidCalculator(taxRateProvider.Object);
            Assert.AreEqual(expectedSupplementAmount, giftAidCalculator.GetGiftAidSupplementAmount(giftAidAmount, (DonationEventType)9999));
        }
    }
}

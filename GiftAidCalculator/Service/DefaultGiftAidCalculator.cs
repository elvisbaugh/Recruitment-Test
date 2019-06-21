
using System.Collections.Generic;
using GiftAidCalculator.Service;

namespace GiftAidCalculator.TestConsole.Service
{
    
        public class DefaultGiftAidCalculator : IGiftAidCalculator
        {
            private readonly ITaxRateProvider _taxRateProvider;
            private static readonly IDictionary<DonationEventType, decimal> _eventTypeRateDictionary
                = new Dictionary<DonationEventType, decimal>
                {
                    { DonationEventType.Default, 0 },
                    { DonationEventType.Running, 5 },
                    { DonationEventType.Swimming, 3 }
                };

            public DefaultGiftAidCalculator(ITaxRateProvider taxRateProvider)
            {
                _taxRateProvider = taxRateProvider;
            }

            public decimal GetGiftAidAmount(decimal donationAmount)
            {
                var gaRatio = GetGiftAidRatio(_taxRateProvider.GetTaxRate());
                return RoundToTwoPlaces(donationAmount * gaRatio);
            }

            // would usually have this in its own class as it feels to be unrelated breaking cohesion, 
            // but seems a bit overkill to do so in this case, perhaps even a simple static helper would be better
            public decimal GetGiftAidSupplementAmount(decimal giftAidAmount, DonationEventType eventType)
            {
                var supplementRate = GetSupplementRate(eventType);
                return RoundToTwoPlaces(giftAidAmount * supplementRate * 0.01m);
            }

            private static decimal GetSupplementRate(DonationEventType eventType)
                => _eventTypeRateDictionary.ContainsKey(eventType) ? _eventTypeRateDictionary[eventType] : 0;

            private static decimal GetGiftAidRatio(decimal taxRate) => taxRate / (100 - taxRate);

            private static decimal RoundToTwoPlaces(decimal val) => decimal.Round(val, 2);
        }
    }

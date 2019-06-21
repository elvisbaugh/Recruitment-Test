using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Service
{
    public interface IGiftAidCalculator
    {
        decimal GetGiftAidAmount(decimal donation);
        decimal GetGiftAidSupplementAmount(decimal giftAidAmount, DonationEventType eventType);
    }
}

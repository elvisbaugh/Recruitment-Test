namespace GiftAidCalculator.TestConsole.Service
{
    public interface IGiftAidCalculator
    {
        decimal GetGiftAidAmount(decimal donation);
        decimal GetGiftAidSupplementAmount(decimal giftAidAmount, DonationEventType eventType);
    }
}

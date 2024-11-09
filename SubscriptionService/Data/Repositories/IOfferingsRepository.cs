namespace SubscriptionService.Data.Repositories;

public interface IOfferingsRepository
{
    public Task<List<string>> GetOfferingsAsync();
}
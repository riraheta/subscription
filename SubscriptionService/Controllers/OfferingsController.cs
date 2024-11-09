using Microsoft.AspNetCore.Mvc;
using SubscriptionService.Data.Repositories;

namespace SubscriptionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferingsController : ControllerBase
{
    private readonly IOfferingsRepository _offeringsRepository;

    public OfferingsController(IOfferingsRepository offeringsRepository)
    {
        _offeringsRepository = offeringsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetOfferings()
    {
        var offerings = await _offeringsRepository.GetOfferingsAsync();

        if (offerings == null)
        {
            return NotFound();
        }

        return offerings;
    }

}
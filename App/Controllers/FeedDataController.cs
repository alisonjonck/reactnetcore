using App.Domain.Interfaces.Services;
using App.Services;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    public class FeedDataController : Controller
    {
        private readonly IFeedServices _feedServices;

        public FeedDataController(IFeedServices feedServices)
        {
            _feedServices = feedServices;
        }

        [HttpGet("[action]")]
        public JsonResult ReturnsFeedInfo(bool isThrottle = false)
        {
            var feedInfo = new FeedInfo(_feedServices.GetFirst10FeedTopics(isThrottle));

            return Json(feedInfo);
        }
    }
}
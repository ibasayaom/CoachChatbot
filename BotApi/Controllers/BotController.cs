using Core.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : ControllerBase
    {      

        private readonly ILogger<BotController> _logger;
        private readonly IBotService _botService;
        public BotController(ILogger<BotController> logger , IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }

        [HttpPost]
        public string GetResponse(string message)
        {
            return _botService.GetResponse(message);
        }
    }
}

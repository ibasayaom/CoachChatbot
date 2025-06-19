using System.ClientModel;
using System.Diagnostics;
using Azure.AI.OpenAI;
using Core.Abstractions.Services;
using CreamSoda.UI.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

namespace CreamSoda.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBotService _botService;

        public HomeController(ILogger<HomeController> logger, IBotService botService)
        {
            _logger = logger;
            _botService = botService ?? throw new ArgumentNullException(nameof(botService));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return Json("Please provide a valid message.");
            }
            // Replace the problematic line with the correct method to create a user message
            var messages = new List<ChatMessage>    {
             new SystemChatMessage(@"You are an HR AI assistance. You name is CreamSoda and your purpose is to assist employees with their onboarding journey. "),
           new UserChatMessage(message)
              };

            var completion = _botService.GetResponse(message);

            return Json(completion);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System.ClientModel;
using System.Diagnostics;
using System.Text.Json;
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using CreamSoda.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace CreamSoda.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatClient _chatClient;
        private readonly ChatCompletionOptions _options = new ChatCompletionOptions
        {
            Temperature = (float)0.7,
            MaxOutputTokenCount = 800,
            TopP = (float)0.95,
            FrequencyPenalty = (float)0,
            PresencePenalty = (float)0
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var endpoint = "https://mission-ctrl-resource.openai.azure.com/";
            // Use DefaultAzureCredential for Entra ID authentication
            var credential = new ApiKeyCredential("CPZv1KFIgVIgqcUjK5aczFFfh1Z92KZHRGAWq0sN0nBFVFZlfdgGJQQJ99BFACHYHv6XJ3w3AAAAACOGpcSB");
            // Initialize the AzureOpenAIClient
            var azureClient = new AzureOpenAIClient(new Uri(endpoint), credential);
            // Initialize the ChatClient with the specified deployment name
            _chatClient = azureClient.GetChatClient("gpt-4o");



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

            // Create chat completion options
            var options = new ChatCompletionOptions
            {
                Temperature = (float)0.7,
                MaxOutputTokenCount = 800,

                TopP = (float)0.95,
                FrequencyPenalty = (float)0,
                PresencePenalty = (float)0
            };

            var completion = _chatClient.CompleteChatAsync(messages, _options).Result;

            var response = completion.Value.Content[0].Text;
            return Json(response);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

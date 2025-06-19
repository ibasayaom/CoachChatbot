using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Core.Abstractions.Services;
using Core.Models;
using OpenAI.Chat;

namespace Core.Services
{
    public class BotService : IBotService
    {
        private readonly ChatClient _chatClient;
        private readonly ApplicationSettings _settings;

        private readonly ChatCompletionOptions _options = new ChatCompletionOptions
        {
            Temperature = (float)0.7,
            MaxOutputTokenCount = 800,
            TopP = (float)0.95,
            FrequencyPenalty = (float)0,
            PresencePenalty = (float)0
        };

        public BotService(  )
        {
            _settings = new ApplicationSettings();
            var credential = new ApiKeyCredential(_settings.ApiKeyCredential);
            // Initialize the AzureOpenAIClient
            var azureClient = new AzureOpenAIClient(new Uri(_settings.AzureEndpoint), credential);
            // Initialize the ChatClient with the specified deployment name
            _chatClient = azureClient.GetChatClient(_settings.ChatClient);
        }
        public string GetResponse(string message)
        {
            // Replace the problematic line with the correct method to create a user message
            var messages = new List<ChatMessage>    {
             new SystemChatMessage(@"You are an HR AI assistance. You name is CreamSoda and your purpose is to assist employees with their onboarding journey. "),
           new UserChatMessage(message)
              };
            var completion = _chatClient.CompleteChatAsync(messages, _options).Result;
            var response = completion.Value.Content[0].Text;
            return response ?? "No response received from the AI.";
        }
    }
}

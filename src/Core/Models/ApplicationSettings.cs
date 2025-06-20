using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ApplicationSettings
    {
        public string  AzureEndpoint { get;set; } = "https://mission-ctrl-resource.openai.azure.com/";
        public string ApiKeyCredential { get; set; } = "CPZv1KFIgVIgqcUjK5aczFFfh1Z92KZHRGAWq0sN0nBFVFZlfdgGJQQJ99BFACHYHv6XJ3w3AAAAACOGpcSB";
        public string ChatClient { get; set; } = "gpt-4o";
        public string GetAgent { get; set; } = "asst_nbJP1uQwXz7fi3m5J1P0moCn"; // This is the deployment name for the chat client

        public string GetThread { get; set; } = "thread_9Ea9z4flWAW5penedKX8P9lZ"; // This is the model name for the chat client
    }
}

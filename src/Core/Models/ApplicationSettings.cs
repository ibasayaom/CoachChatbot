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
    }
}

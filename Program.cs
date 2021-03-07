using Newtonsoft.Json.Linq;
using System; 
using CDS.Authorization;
using CDS.DynamicAPI;
using CDS.DynamicAPI.Mockup;
using System.IO;

namespace CDS
{
    class Program
    {
        static void Main(string[] args)
        {
            var credential=JObject.Parse(File.ReadAllText(@"Credential.json")); 
            var clientAzure = new ClientAzureAuth(
                (string)credential["serviceUrl"], 
                (string)credential["clientId"], 
                (string)credential["clientSecret"], 
                (string)credential["tenatId"]);
            var service = new DynamicService(clientAzure.GetAuthToken(), (string)credential["rootApiCrm"]);
            var contact = new JObject()
            {
                ["firstname"] = "Brick",
                ["lastname"] = "Nikols",
            };
            var id =  service.Create("contact",contact);
            Console.WriteLine(id);
            Console.WriteLine("Done");

            Console.ReadLine();
        } 
    } 
}

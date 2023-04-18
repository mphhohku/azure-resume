using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker.Http;

namespace Company.Function
{
    public class GetResumeCounter
    {
        private readonly ILogger _logger;

        public GetResumeCounter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetResumeCounter>();
        }
        private static readonly string databaseName = "AzureResume";
        private static readonly string collectionName = "Counter";
        private static readonly string id = "1";
        private static readonly string partitionKey = "1";

        [Function("GetResumeCounter")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Launch a Cosmos Client
            var client = new CosmosClient(Environment.GetEnvironmentVariable("AzureResumeConnectionString"));
            var database = client.GetDatabase(databaseName);
            var container = database.GetContainer(collectionName);

            // Read the current count from the database
            var responsedb = await container.ReadItemAsync<Counter>(id, new PartitionKey(partitionKey));
            var counter = responsedb.Resource;
            int count = counter.Count;

            // Increase the count by 1
            count++;
            counter.Count = count;

            // Update the count in the database
            await container.ReplaceItemAsync(counter, id, new PartitionKey(partitionKey));

            // Return the updated count as a JSON string
            var json = JsonConvert.SerializeObject(counter);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(json);
            return response;
        }
    }
}
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Text;

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
        private static readonly string connectionString = "AzureResumeConnectionString";
        private static readonly string id = "1";
        private static readonly string partitionKey = "1";

        [Function("GetResumeCounter")]
        public static async Task<HttpResponseMessage> Run(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
           // [CosmosDB(databaseName:"AzureResume",collectionName:"Counter",ConnectionString="AzureResumeConnectionString", Id="1", PartitionKey="1")] Counter counter,
           // [CosmosDB(databaseName:"AzureResume",collectionName:"Counter",ConnectionString="AzureResumeConnectionString", Id="1", PartitionKey="1")] out Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("Visitor counter triggered.");

            // updatedCounter = counter;
            // updatedCounter.Count += 1;

            // var jsonToReturn = JsonConvert.SerializeObject(counter);

            // return new HttpResponseMessage(HttpStatusCode.OK)
            // {
            //   Content = new StringContent(jsonToReturn, System.Text.Encoding.UTF8, "application/json")
            // };
        
        // Get the Cosmos DB client instance
try
            {
                // Connect to Cosmos DB database
                var client = new CosmosClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var container = database.GetContainer(collectionName);

                // Read the current count from the database
                var response = await container.ReadItemAsync<Counter>(id, new PartitionKey(partitionKey));
                var counter = response.Resource;
                int count = counter.Count;

                // Increase the count by 1
                count++;
                counter.Count = count;

                // Update the count in the database
                await container.ReplaceItemAsync(counter, id, new PartitionKey(partitionKey));

                // Return the updated count as a JSON string
                var json = JsonConvert.SerializeObject(counter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Failed to count visitors");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
using Newtonsoft.Json;

namespace Company.Function
{
    public class Counter
    {
        [JsonProperty("id")] //the property name string is case-sensitive!
        public string Id {get; set;} = "1";
        
        [JsonProperty("partitionKey")]
        public string PartitionKey { get; set; } = "1";

        [JsonProperty("count")]
        public int Count {get; set;} 
    }
}

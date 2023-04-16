using Newtonsoft.Json;

namespace Company.Function
{
    public class Counter
    {
        [JsonProperty(PropertyName="id")] //the property name string is case-sensitive!
        public string Id {get; set;} = "1";
        
        [JsonProperty(PropertyName="partitionKey")]
        public string PartitionKey { get; set; } = "1";

        [JsonProperty(PropertyName="count")]
        public int Count {get; set;} 
    }
}


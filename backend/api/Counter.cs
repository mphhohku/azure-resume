using Newtonsoft.Json;

namespace Company.Function
{
    public class Counter
    {
        [JsonProperty(PropertyName="id")] //the property name string is case-sensitive!
        public string Id {get; set;} = "1";
        
        [JsonProperty(PropertyName="PartitionKey")]
        public string PartitionKey { get; set; } = "1";

        [JsonProperty(PropertyName="Count")]
        public int Count {get; set;} 
    }
}


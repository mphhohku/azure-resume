public class Counter
    {
        [JsonProperty(PropertyName="Id")]
        public string Id {get; set;} = "1";
        
        [JsonProperty(PropertyName="PartitionKey")]
        public string PartitionKey { get; set; } = "1";

        [JsonProperty(PropertyName="Count")]
        public int Count {get; set;} 
    }
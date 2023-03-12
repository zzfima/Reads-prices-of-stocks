using Newtonsoft.Json;

namespace Service.Models
{
    /// <summary>
    /// Stock entity
    /// </summary>
    public class Stock
    {
        [JsonProperty("price")]
        public float price { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}

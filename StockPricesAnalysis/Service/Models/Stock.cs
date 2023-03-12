using Newtonsoft.Json;

namespace Service.Models
{
    /// <summary>
    /// Stock entity
    /// </summary>
    public class Stock
    {
        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("volume")]
        public float Volume { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}

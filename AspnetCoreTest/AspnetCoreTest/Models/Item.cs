using System.Text.Json.Serialization;

namespace AspnetCoreTest.Models
{
    public class Item
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace HDRUK_DevTest.Models
{
    public class HealthDataModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("accessServiceCategory")]
        public string AccessServiceCategory { get; set; }

        [JsonPropertyName("accessRights")]
        public string AccessRights { get; set; }
    }
}

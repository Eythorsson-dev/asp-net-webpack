using Newtonsoft.Json;

namespace asp_net_webpack.Core.ExternalApi.ExampleAuthApi.Dto.Data
{
    internal class DataRequestDto
    {

        [JsonProperty("product_no")]
        public string ProductNo { get; set; }
    }
}

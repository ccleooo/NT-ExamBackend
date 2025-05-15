using Newtonsoft.Json;

namespace ExamBackend.Models
{
    public class TableInfo
    {
        [JsonProperty("diagramId")]
        public string DiagramID { get; set; }
        [JsonProperty("diagramName")]
        public string DiagramName { get; set; }
        [JsonProperty("identify")]
        public string Identify { get; set; }
        [JsonProperty("mTable")]
        public string MTable { get; set; }
        [JsonProperty("sTable")]
        public string STable { get; set; }
        [JsonProperty("lTable")]
        public string LTable { get; set; }
    }

}

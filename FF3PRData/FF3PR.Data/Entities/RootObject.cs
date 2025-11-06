using System.Collections.Generic;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Root class containing all classes which correspond to objects found in the map entity script files
    // Used to edit various objects found in maps (mainly treasure chests)
    public class RootObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opacity")]
        public float Opacity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}




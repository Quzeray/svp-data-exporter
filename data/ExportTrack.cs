using System.Collections.Generic;

namespace ExportVegasData
{
    public class ExportTrack
    {
        public ExportTrack(string name, string mediaType, List<MediaElement> mediaElements)
        {
            Name = name;
            MediaType =  mediaType;
            MediaElements = mediaElements;
        }

        public string Name { get; set; }
        public string MediaType { get; set; }
        
        public List<MediaElement> MediaElements { get; set; } 
    }
}

using System.Collections.Generic;

namespace ExportVegasData
{
    public class ProjectData
    {
        public string ProjectName { get; set; }
        public string FilePath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double PixelAspectRatio { get; set; }
        public double FrameRate { get; set; }
        public string Length { get; set; }

        public List<ExportTrack> Tracks { get; set; }
    }
}

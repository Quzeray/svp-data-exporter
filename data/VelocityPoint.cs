using System;

namespace ExportVegasData
{ 
    class VelocityPoint
    {
        public VelocityPoint(string timecode, double value)
        {
            Timecode = timecode;
            Value = Math.Round(value, 2);
        }

        public string Timecode { get; set; }
        public double Value { get; set; }
    }
}

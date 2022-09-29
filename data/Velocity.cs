using System.Collections.Generic;

namespace ExportVegasData
{
    class Velocity
    {
        public Velocity(List<VelocityPoint> velocityPoints)
        {
            VelocityPoints = velocityPoints;
        }
        public List<VelocityPoint> VelocityPoints { get; set; }
    }
}

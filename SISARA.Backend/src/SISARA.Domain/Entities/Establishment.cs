using SISARA.Domain.Common;

namespace SISARA.Domain.Entities
{
    public class Establishment : BaseAuditableEntity
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Point1Latitude { get; set; }
        public decimal Point1Longitude { get; set; }
        public decimal Point2Latitude { get; set;}
        public decimal Point2Longitude { get; set;}
        public decimal Point3Latitude { get; set;}
        public decimal Point3Longitude { get; set;}
        public decimal Point4Latitude { get; set;}
        public decimal Point4Longitude { get; set;}
    
    }
}

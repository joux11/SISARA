using SISARA.Domain.Common;

namespace SISARA.Domain.Entities
{
    public class Fines : BaseAuditableEntity
    {
        public uint Id { get; set; }
        public decimal FineAmount { get; set; }
        public string Reason { get; set; }
        public uint AttendanceRecordId { get; set; }
    }
}

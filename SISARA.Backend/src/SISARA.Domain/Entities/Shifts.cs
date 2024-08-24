using SISARA.Domain.Common;
using SISARA.Domain.ValueObjects;

namespace SISARA.Domain.Entities
{
    public class Shifts : BaseAuditableEntity
    {
        public uint Id { get; set; }
        public Weekday Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int AllowedLateTime { get; set; }
        public LateAllowanceUnit LateAllowanceUnit { get; set; }
        public uint EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
    }
}

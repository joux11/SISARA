namespace SISARA.Domain.Entities
{
    public class AttendanceRecord
    {
        public uint Id { get; set; }
        public DateTime RecordDate { get; set; }
        public TimeSpan CheckinTime { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public uint UserId { get; set; }
        public uint ShiftId {  get; set; }
    }
}

namespace SISARA.Domain.Entities
{
    public class UserDevice
    {
        public uint Id { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime CreatedBy { get; set; }
        public uint UserId { get; set; }
        public User User { get; set; }  

    }
}

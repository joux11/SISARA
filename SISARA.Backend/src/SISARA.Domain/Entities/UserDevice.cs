namespace SISARA.Domain.Entities
{
    public class UserDevice
    {
        public uint Id { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public uint UserId { get; set; }
        //public User User { get; set; }  

    }
}

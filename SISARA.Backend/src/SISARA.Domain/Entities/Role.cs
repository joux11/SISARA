namespace SISARA.Domain.Entities
{
    public class Role
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}

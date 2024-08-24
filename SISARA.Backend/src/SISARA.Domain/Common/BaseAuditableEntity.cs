namespace SISARA.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        public virtual void OnSaveAuditable()
        {
            if(CreatedAt == default(DateTime))
            {
                CreatedAt = DateTime.Now;
            }
            UpdatedAt = DateTime.Now;
        }
    }
}

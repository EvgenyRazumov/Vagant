namespace Vagant.Domain.Entities
{
    public class EventImage : BaseEntity
    {
        public int ImageFileId { get; set; }

        public int EventId { get; set; }

        public virtual ImageFile ImageFile { get; set; }

        public virtual Event Event { get; set; }
    }
}

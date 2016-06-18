namespace Vagant.Domain.Entities
{
    public class EventComment : BaseEntity
    {
        public string Text { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}

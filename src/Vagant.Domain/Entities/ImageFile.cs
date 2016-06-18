namespace Vagant.Domain.Entities
{
    public class ImageFile : BaseEntity
    {
        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}

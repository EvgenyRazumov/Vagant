using System.Collections.Generic;
using Vagant.Domain.Entities;

namespace Vagant.Domain.Services
{
    public interface IImageFileService
    {
        void Create(ImageFile entity);

        ImageFile Get(int id);

        IEnumerable<ImageFile> Get(IEnumerable<int> ids);
    }
}

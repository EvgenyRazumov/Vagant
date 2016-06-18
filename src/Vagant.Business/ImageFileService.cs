using System.Collections.Generic;
using System.Linq;
using Vagant.Domain.Entities;
using Vagant.Domain.Services;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Business
{
    public class ImageFileService : IImageFileService
    {
        private readonly IAppUnitOfWork _uow;

        public ImageFileService(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(ImageFile entity)
        {
            var imageRepository = _uow.GetRepository<ImageFile>();
            imageRepository.Create(entity);
            _uow.Commit();
        }

        public IEnumerable<ImageFile> Get(IEnumerable<int> ids)
        {
            var imageRepository = _uow.GetRepository<ImageFile>();
            return imageRepository.Get(x => ids.Contains(x.Id));
        }

        public ImageFile Get(int id)
        {
            var imageRepository = _uow.GetRepository<ImageFile>();
            return imageRepository.GetByKey(id);
        }
    }
}

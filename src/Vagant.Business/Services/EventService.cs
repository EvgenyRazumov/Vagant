using System;
using Vagant.Domain.Entities;
using Vagant.Domain.Models;
using Vagant.Domain.Services;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IAppUnitOfWork _uow;

        public EventService(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public int CreateEvent(EventModel model)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var eventImageRepository = _uow.GetRepository<EventImage>();

            var @event = new Event
            {
                Location = new Location()
            };

            Map(model, @event);
            eventRepository.Create(@event);

            foreach (var image in model.Images)
            {
                eventImageRepository.Create(new EventImage
                {
                    EventId = @event.Id,
                    ImageFileId = image
                });
            }
            _uow.Commit();

            return @event.Id;
        }

        public void UpdateEvent(EventModel model)
        {
            var eventRepository = _uow.GetRepository<Event>();

            var @event = eventRepository.GetByKey(model.Id);
            if (@event == null)
            {
                throw new ArgumentNullException();
            }

            Map(model, @event);
            eventRepository.Update(@event);
            _uow.Commit();
        }

        public double UpdateRating(int eventId, int newValue)
        {
            var eventRepository = _uow.GetRepository<Event>();

            var @event = eventRepository.GetByKey(eventId);
            if (@event == null)
            {
                throw new ArgumentNullException();
            }

            if (@event.VotesNumber == 0)
            {
                @event.Rate = newValue;
            }
            else
            {
                @event.Rate = (@event.Rate * @event.VotesNumber + newValue) / (@event.VotesNumber + 1);
            }
            @event.VotesNumber++;

            eventRepository.Update(@event);
            _uow.Commit();

            return @event.Rate;
        }

        private void Map(EventModel model, Event entity)
        {
            entity.AuthorId = model.AuthorId;
            entity.BriefDescription = model.BriefDescription;
            entity.EndTime = model.EndTime;
            entity.FullDescription = model.FullDescription;
            entity.LogoId = model.LogoId;
            entity.StartTime = model.StartTime;
            entity.Title = model.Title;

            if (entity.Location != null)
            {
                entity.Location.Latitude = model.Latitude;
                entity.Location.Longitude = model.Longitude;
                entity.Location.DisplayName = model.LocationDisplayName;
            }
        }
    }
}

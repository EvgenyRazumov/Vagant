using System;
using System.Collections.Generic;
using System.Linq;
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

            var @event = new Event
            {
                Location = new Location(),
                EventInstrument = new EventInstrument()
            };

            MapToEntity(model, @event);
            eventRepository.Create(@event);
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

            MapToEntity(model, @event);
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

        public EventModel GetEvent(int eventId)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var @event = eventRepository.GetByKey(eventId);
            return GetModel(@event);
        }

        public IList<EventModel> GetEvents(DateTime startDate, DateTime endDate)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var events = eventRepository.Get(x => x.StartTime >= startDate.Date && x.StartTime <= endDate.Date);
            return events.Select(GetModel).ToList();
        }

        private void MapToEntity(EventModel model, Event entity)
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
            }

            if (entity.EventInstrument != null)
            {
                entity.EventInstrument.IsGuitarUsed = model.IsGuitarUsed;
                entity.EventInstrument.IsViolinUsed = model.IsViolinUsed;
                entity.EventInstrument.IsVocalApplicable = model.IsVocalApplicable;
            }
        }

        private EventModel GetModel(Event entity)
        {
            var model = new EventModel();

            model.Id = entity.Id;
            model.AuthorId = entity.AuthorId;
            model.BriefDescription = entity.BriefDescription;
            model.EndTime = entity.EndTime;
            model.FullDescription = entity.FullDescription;
            model.LogoId = entity.LogoId;
            model.StartTime = entity.StartTime;
            model.Title = entity.Title;
            model.AuthorName = string.Format("{0} {1}", entity.Author.FirstName, entity.Author.LastName);

            if (entity.Location != null)
            {
                model.Latitude = entity.Location.Latitude;
                model.Longitude = entity.Location.Longitude;
            }

            if (entity.EventInstrument != null)
            {
                model.IsGuitarUsed = entity.EventInstrument.IsGuitarUsed;
                model.IsViolinUsed = entity.EventInstrument.IsViolinUsed;
                model.IsVocalApplicable = entity.EventInstrument.IsVocalApplicable;
            }

            return model;
        }
    }
}

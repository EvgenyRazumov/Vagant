using System;
using System.Collections.Generic;
using Vagant.Domain.Entities;
using Vagant.Domain.Models;

namespace Vagant.Domain.Services
{
    public interface IEventService
    {
        int CreateEvent(EventModel model);

        void UpdateEvent(EventModel model);

        double UpdateRating(string userId, int eventId, int ratingValue);

        bool IsRatingEditable(string userId, int eventId);

        EventModel GetEvent(int eventId);

        IList<EventModel> GetEvents(DateTime startDate, DateTime endDate);

        void CreateComment(EventComment comment);
    }
}

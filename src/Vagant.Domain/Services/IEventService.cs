using Vagant.Domain.Models;

namespace Vagant.Domain.Services
{
    public interface IEventService
    {
        int CreateEvent(EventModel model);

        void UpdateEvent(EventModel model);

        double UpdateRating(int eventId, int newValue);
    }
}

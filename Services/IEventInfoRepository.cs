using Events.Entities;

namespace Events.Services
{

    public interface IEventInfoRepository
    {
        IEnumerable<Entities.Event> GetEventsAsync();

        IEnumerable<Entities.EventType> GetEventTypesForEventAsync(Events.Entities.Event eventObj);
      
        Task<Entities.Event?> GetEventAsync(int EventId, bool includeEventType);
        Task<bool> EventExistsAsync(int EventId);
        Task<IEnumerable<EventType>> GetEventTypeForEventAsync(int EventId);
    
         
    }
}



using Events.DbContexts;
using Events.Entities;
using Events.Services;
using Microsoft.EntityFrameworkCore;

namespace Event.Services
{
    public class EventInfoRepository : IEventInfoRepository
    {
        private readonly EventInfoContext _context;

        public EventInfoRepository(EventInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Events.Entities.Event> GetEventsAsync()
        {
            return  _context.Events.OrderBy(c => c.Title).ToList();
        }

        public async Task<Events.Entities.Event?> GetEventAsync(int EventId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return await _context.Events.Include(c => c.EventType)
                    .Where(c => c.Id == EventId).FirstOrDefaultAsync();
            }

            return await _context.Events
                  .Where(c => c.Id == EventId).FirstOrDefaultAsync();
        }

        public async Task<bool> EventExistsAsync(int EventId)
        {
            return await _context.Events.AnyAsync(c => c.Id == EventId);
        }

        public async Task<EventType?> GetEventTypeForEventAsync(
            int EventId,
            int EventTypeId)
        {
            return await _context.EventTypes
               .Where(p => p.Id == EventId && p.Id == EventTypeId)
               .FirstOrDefaultAsync();
        }

        public IEnumerable<EventType> GetEventTypesForEventAsync(
            Events.Entities.Event eventObj)
        {
            return _context.EventTypes
                           .Where(p => p.Id == eventObj.EventTypeId).ToList();
        }

        public Task<IEnumerable<Events.Entities.Event>> GetEventAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventType>> GetEventTypeForEventAsync(int EventId)
        {
            throw new NotImplementedException();
        }


        

      

    }
}


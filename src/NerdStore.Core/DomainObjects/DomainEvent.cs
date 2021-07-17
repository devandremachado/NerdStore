using NerdStore.Shared.Messages;
using System;

namespace NerdStore.Shared.DomainObjects
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggredateId)
        {
            AggregateId = aggredateId;
        }
    }
}

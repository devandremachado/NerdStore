using NerdStore.Shared.Messages;
using System;

namespace NerdStore.Shared.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggredateId)
        {
            AggregateId = aggredateId;
        }
    }
}

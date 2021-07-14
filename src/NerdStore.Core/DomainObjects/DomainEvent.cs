﻿using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggredateId)
        {
            AggregateId = aggredateId;
        }
    }
}

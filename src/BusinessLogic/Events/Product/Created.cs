﻿using OpenCqrs.Events;

namespace OpenCqrsCli.Events.Product
{
    public class CreatedEvent : IEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

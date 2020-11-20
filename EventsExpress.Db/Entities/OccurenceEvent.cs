﻿using System;
using EventsExpress.Db.Enums;

namespace EventsExpress.Db.Entities
{
    public class OccurenceEvent : ManageableEvent
    {
        public int Frequency { get; set; }

        public DateTime LastRun { get; set; }

        public DateTime NextRun { get; set; }

        public Periodicity Periodicity { get; set; }

        public bool IsActive { get; set; }

        public Guid EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
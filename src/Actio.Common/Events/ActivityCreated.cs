﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Name { get; }
        public string Category { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }

        protected ActivityCreated()
        {
            
        }

        public ActivityCreated(Guid id, Guid userId, string category)
        {
            Id = id;
            UserId = userId;
            Category = category;
        }
    }
}

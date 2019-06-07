using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Activities.Domain.Models
{
    public class Category
    {
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
        protected Category()
        {
            
        }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}

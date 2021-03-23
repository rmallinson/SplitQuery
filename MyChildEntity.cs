using System;

namespace SplitQuery
{
    public class MyChildEntity : MyBaseEntity
    {
        public string Name { get; set; }
        public Guid MyEntityId { get; set; }
        public virtual MyEntity MyEntity { get; set; }
    }
}
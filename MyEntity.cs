using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SplitQuery
{
    public class MyEntity : MyBaseEntity
    {
        public string Name { get; set; }
        public virtual IList<MyChildEntity> MyChildEntities { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace SplitQuery
{
    public abstract class MyBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
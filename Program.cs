using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SplitQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = Guid.NewGuid();
            var myEntity = new MyEntity{
                Id = id,
                Name = nameof(MyEntity),
                MyChildEntities = new List<MyChildEntity> {
                    new MyChildEntity {
                        Name = nameof(MyChildEntity)
                    }
                }
            };

            var context = new MyContext("Test");

            context.MyEntities.Add(myEntity);
            context.SaveChanges();

            var passes = context.MyEntities
                .Include(nameof(MyEntity.MyChildEntities))
                .AsSplitQuery()
                .FirstOrDefault();

            var failsForSomeUnknownReason = context
                .GetQueryable<MyBaseEntity>(nameof(MyEntity))
                .Include(nameof(MyEntity.MyChildEntities))
                .AsSplitQuery()
                .FirstOrDefault();
        }
    }
}

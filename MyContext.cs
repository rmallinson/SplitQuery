using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SplitQuery
{
    public class MyContext : DbContext
    {
        private static DbContextOptions<MyContext> BuildOptions(string name)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseInMemoryDatabase(name);
            return optionsBuilder.Options;
        }

        public MyContext(string name) : base(BuildOptions(name))
        {

        }

        public IQueryable<T> GetQueryable<T>(string entityTypeName) => 
            typeof(MyContext).GetProperties()
                .FirstOrDefault(t => t.PropertyType.GenericTypeArguments[0].Name == entityTypeName)
                .GetValue(this) as IQueryable<T>;
        
        
        public DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<MyChildEntity> MyChildEntities { get; set; }
    }
}
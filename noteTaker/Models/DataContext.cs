using Microsoft.EntityFrameworkCore;

namespace noteTaker.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<note> notes { get; set; }
        // override unnecesarry?  Might be confusion with appsettings connections and builder in Program.cs.  Seems to work for now
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=UserNotes.db");
    }
}

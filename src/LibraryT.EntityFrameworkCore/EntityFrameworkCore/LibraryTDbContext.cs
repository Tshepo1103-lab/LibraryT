using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibraryT.Authorization.Roles;
using LibraryT.Authorization.Users;
using LibraryT.MultiTenancy;
using LibraryT.Domain;

namespace LibraryT.EntityFrameworkCore
{
    public class LibraryTDbContext : AbpZeroDbContext<Tenant, Role, User, LibraryTDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public LibraryTDbContext(DbContextOptions<LibraryTDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Notification> Notifications {  get; set; }
        public DbSet<AppConfiguration> AppConfigurations { get; set; }
        public DbSet<TradingHour> TradingHours { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}

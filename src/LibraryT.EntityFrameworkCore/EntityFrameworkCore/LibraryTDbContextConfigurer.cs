using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryT.EntityFrameworkCore
{
    public static class LibraryTDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibraryTDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibraryTDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

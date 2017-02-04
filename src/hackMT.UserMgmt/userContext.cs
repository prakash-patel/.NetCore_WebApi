
using Microsoft.EntityFrameworkCore;
using hackMT.UserMgmt.model;

namespace hackMT.UserMgmt
{
 public class UserDbContext : DbContext
    {
        public DbSet<user> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./UserMgmt.db");
        }
    }
}
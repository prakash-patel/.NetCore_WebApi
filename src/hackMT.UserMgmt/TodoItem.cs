using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace hackMT.UserMgmt
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Todo.db");
        }
    }

    public class TodoItem
    {
        [Key]
        public int TodoId { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
    }
}

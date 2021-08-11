using Microsoft.EntityFrameworkCore;
using FirstWebApi.Models;

namespace FirstWebApi.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base (options)
        {

        }

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}

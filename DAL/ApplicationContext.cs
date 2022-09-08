using DAL.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options ) : base( options ) { }

        public ApplicationContext() { }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}

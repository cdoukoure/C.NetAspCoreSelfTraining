using Microsoft.EntityFrameworkCore;
using WebAspCoreDapper.Models;

namespace WebAspCoreDapper.DAL
{
    public class ContactContext : DbContext
    {


        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Employees { get; set; }
        

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}

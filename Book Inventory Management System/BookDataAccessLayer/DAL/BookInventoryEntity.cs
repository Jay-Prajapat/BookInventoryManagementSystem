using BookDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDataAccessLayer.DAL
{
    public class BookInventoryEntity:DbContext
    {
        public BookInventoryEntity() : base("name=BookInventoryEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookInventoryEntity, BookDataAccessLayer.Migrations.Configuration>());
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}

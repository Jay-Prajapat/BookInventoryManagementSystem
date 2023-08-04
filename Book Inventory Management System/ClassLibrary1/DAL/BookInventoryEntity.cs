using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAL
{
    public class BookInventoryEntity: DbContext
    {
       
        public BookInventoryEntity() : base("name=BookInventoryEntity") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookInventoryEntity, ClassLibrary1.Migrations.Configuration>());
        }
        

        public DbSet<Book> Books { get; set; }
    }
}

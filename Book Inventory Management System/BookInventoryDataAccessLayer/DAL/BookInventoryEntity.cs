using BookInventoryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryDataAccessLayer.DAL
{
    public class BookInventoryEntity:DbContext
    {
        public BookInventoryEntity()
        {
            
        }
        public BookInventoryEntity(DbContextOptions<BookInventoryEntity> option):base(option) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=sf-cpu-336\SQLEXPRESS;Initial Catalog=DesignPatterns;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Book> Books { get; set; }
    }
}

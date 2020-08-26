using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4_27EFImageProject.Data
{
    public class ImageContext : DbContext
    {
        private readonly string _connectionString;

        public ImageContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        
        public DbSet<Image> Images { get; set; }
    }
}

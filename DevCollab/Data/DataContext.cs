﻿global using Microsoft.EntityFrameworkCore;
using DevCollab.Models;

namespace DevCollab.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=KRSANINSTE\\SQLEXPRESS;Database=usersdb;Trusted_Connection=true;TrustServerCertificate=true;");
                

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }


    }
}

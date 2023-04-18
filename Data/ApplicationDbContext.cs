using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoPic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoPic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Photo>()
                .HasOne(c => c.Genre)
                .WithMany(b => b.Photo)
                .HasForeignKey(p => p.GenreId);
        }
    }
}

﻿using vue_kintai.Models;
using Microsoft.EntityFrameworkCore;

namespace vue_kintai.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<AttendTime> AttendTime { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.AttendTimes)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        }
    }
}

﻿using Microsoft.EntityFrameworkCore;

namespace noteTaker.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<note> notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=UserNotes.db");
    }
}

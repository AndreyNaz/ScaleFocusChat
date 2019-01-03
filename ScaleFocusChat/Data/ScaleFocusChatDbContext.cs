using Microsoft.EntityFrameworkCore;
using ScaleFocusChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Data
{
    public class ScaleFocusChatDbContext : DbContext
    {
        public ScaleFocusChatDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupsUsers { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupUser>()
            .HasKey(u => new { u.GroupId, u.UserId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.GroupUsers)
                .HasForeignKey(gu => gu.GroupId);

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.User)
                .WithMany(u => u.GroupUsers)
                .HasForeignKey(gu => gu.UserId);
        }
    }
}

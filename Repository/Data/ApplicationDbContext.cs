using System;
using System.Collections.Generic;
using System.Text;
using MatrimonialProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MatrimonialProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
//using System.Data.Entity;

namespace MatrimonialProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //AspNetRoles
        
        public DbSet<Message> Message { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Roles.Add(new IdentityRole { Id = "1", Name = "Administrator", NormalizedName = "Admin" });
           // Roles.Add(new IdentityRole { Id = "2", Name = "Client", NormalizedName = "Client" });
            


            modelBuilder.Entity<Message>().HasKey(sc => sc.MessageId);

            modelBuilder.Entity<Message>()
               
                .HasOne(s => s.Sender)
                .WithMany(m => m.SentMessage)
                .HasForeignKey(k => k.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(s => s.Receiver)
                .WithMany(m => m.ReceiveMessage)
                .HasForeignKey(k => k.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<MatrimonialProject.ViewModels.UserViewModel> UserViewModel { get; set; }
       
        public DbSet<Description> Description { get; set; }
        
    }
   
}

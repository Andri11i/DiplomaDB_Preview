using System;
using System.Collections.Generic;
using DiplomaDB_Preview.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomaDB_Preview.Data;

public partial class DiplomaDbPreviewContext : DbContext
{
    public DiplomaDbPreviewContext()
    {
    }

    public DiplomaDbPreviewContext(DbContextOptions<DiplomaDbPreviewContext> options)
        : base(options)
    {
    }

    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    
    DbSet<Category> Categories { get; set; }
    DbSet<Event> Events { get; set; }

    DbSet<Participant> Participants { get; set; }
    DbSet<Sponsor> Sponsors { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Rating> Ratings { get; set; }
    DbSet<Statistic> Statistics { get; set; }
    DbSet<Favorite> Favorites { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TUF;Initial Catalog=Diploma_DB_Preview;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        //modelBuilder.Entity<Comment>().
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using EFGetstarted;

public class BloggingContext : DbContext
{
 
    public DbSet<EFGetstarted.Task> Tasks { get; set; }
    public DbSet<ToDo> Todos { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<TeamWorker> TeamsWorkers { get; set; }



    public string DbPath { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TeamWorker>()
            .HasKey(p => new { p.TeamId, p.WorkerId });
    }   
    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
        Console.WriteLine("Database location : " + DbPath);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

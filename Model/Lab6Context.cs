using System;
using Microsoft.EntityFrameworkCore;

public class Lab6Context : DbContext
{
    public Lab6Context(DbContextOptions<Lab6Context> options)
        : base(options)
    {
    }

    public DbSet<Party> Parties { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
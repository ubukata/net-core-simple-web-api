using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab6.Migrations
{
    [DbContext(typeof(Lab6Context))]
    partial class Lab6ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("Party", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ExpectedNumberOfGuests");

                    b.Property<DateTime>("PartyDate");

                    b.Property<string>("PartyName");

                    b.HasKey("PartyId");

                    b.ToTable("Parties");
                });
        }
    }
}

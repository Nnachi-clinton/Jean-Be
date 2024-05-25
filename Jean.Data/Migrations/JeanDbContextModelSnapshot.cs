﻿// <auto-generated />
using System;
using Jean.Data.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jean.Data.Migrations
{
    [DbContext(typeof(JeanDbContext))]
    partial class JeanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Jean.Model.Domains.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Search")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SearchTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}

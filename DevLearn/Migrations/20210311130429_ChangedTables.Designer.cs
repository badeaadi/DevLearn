﻿// <auto-generated />
using System;
using DevLearn.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TestsData.Migrations
{
    [DbContext(typeof(TestsDataContext))]
    [Migration("20210311130429_ChangedTables")]
    partial class ChangedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevLearn.Models.Author", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdAuthor")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.HasKey("IdAuthor");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("DevLearn.Models.Lecture", b =>
                {
                    b.Property<int>("IdLecture")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("AuthorIdAuthor");

                    b.HasKey("IdLecture");

                    b.HasIndex("AuthorIdAuthor");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("DevLearn.Models.Slide", b =>
                {
                    b.Property<int>("IdSlide")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("LectureIdLecture");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("IdSlide");

                    b.HasIndex("LectureIdLecture");

                    b.ToTable("Slide");
                });

            modelBuilder.Entity("DevLearn.Models.Lecture", b =>
                {
                    b.HasOne("DevLearn.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorIdAuthor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DevLearn.Models.Slide", b =>
                {
                    b.HasOne("DevLearn.Models.Lecture")
                        .WithMany("Slides")
                        .HasForeignKey("LectureIdLecture");
                });
#pragma warning restore 612, 618
        }
    }
}
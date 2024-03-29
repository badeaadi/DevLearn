﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DevLearn.DatabaseContext;

namespace TestsData.Migrations
{
    [DbContext(typeof(TestsDataContext))]
    [Migration("20210113125750_Mig")]
    partial class Mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestsData.Author", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdAuthor")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("IdAuthor");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("TestsData.Item", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemInformation");

                    b.Property<int>("RightVariant");

                    b.HasKey("IdItem");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TestsData.Lecture", b =>
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

            modelBuilder.Entity("TestsData.Slide", b =>
                {
                    b.Property<int>("IdSlide")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Information")
                        .IsRequired();

                    b.Property<int?>("LectureIdLecture");

                    b.HasKey("IdSlide");

                    b.HasIndex("LectureIdLecture");

                    b.ToTable("Slide");
                });

            modelBuilder.Entity("TestsData.Variant", b =>
                {
                    b.Property<int>("IdVariant")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemIdItem");

                    b.Property<string>("VariantInformation");

                    b.HasKey("IdVariant");

                    b.HasIndex("ItemIdItem");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("TestsData.Lecture", b =>
                {
                    b.HasOne("TestsData.Author", "Author")
                        .WithMany("Lectures")
                        .HasForeignKey("AuthorIdAuthor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestsData.Slide", b =>
                {
                    b.HasOne("TestsData.Lecture")
                        .WithMany("Slides")
                        .HasForeignKey("LectureIdLecture");
                });

            modelBuilder.Entity("TestsData.Variant", b =>
                {
                    b.HasOne("TestsData.Item")
                        .WithMany("Variants")
                        .HasForeignKey("ItemIdItem");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using BookStoreWebAPI.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreWebAPI.API.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreWebAPI.API.Models.Domain.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("a8210012-4e0b-4f8c-b4e0-0857e8de30b0"),
                            Country = "United States",
                            Name = "John Doe"
                        },
                        new
                        {
                            AuthorId = new Guid("e9831d11-87ae-4540-9b9c-3c04b3c71cc7"),
                            Country = "United Kingdom",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            AuthorId = new Guid("92fda86a-c051-4c4d-819e-cde2abbc0971"),
                            Country = "Canada",
                            Name = "Michael Johnson"
                        },
                        new
                        {
                            AuthorId = new Guid("d69536a2-71c8-43ac-aed3-0209a4f5a8db"),
                            Country = "Australia",
                            Name = "Emily Brown"
                        },
                        new
                        {
                            AuthorId = new Guid("1f4e4f7c-6377-473f-bb25-0b31a1c95af3"),
                            Country = "India",
                            Name = "William Lee"
                        },
                        new
                        {
                            AuthorId = new Guid("9a1ab2f9-d8c0-4a0c-a185-40e9137ef5a2"),
                            Country = "South Korea",
                            Name = "Sophia Kim"
                        });
                });

            modelBuilder.Entity("BookStoreWebAPI.API.Models.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreWebAPI.API.Models.Domain.Genre", b =>
                {
                    b.Property<Guid>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = new Guid("2ecdf04f-70cd-4df7-aaed-5e84221cbace"),
                            GenreName = "Fiction"
                        },
                        new
                        {
                            GenreId = new Guid("9f0bfd52-5aff-4b2b-9fb4-751ec7c53be0"),
                            GenreName = "Mystery"
                        },
                        new
                        {
                            GenreId = new Guid("25290ad1-9ff5-4ed7-817e-3d90ff2f600e"),
                            GenreName = "Romance"
                        },
                        new
                        {
                            GenreId = new Guid("f76e5b2b-8ef8-45e4-a910-93bc89e68dac"),
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            GenreId = new Guid("e786fcd3-0a66-4e12-85c4-86f27886dde4"),
                            GenreName = "Fantasy"
                        });
                });

            modelBuilder.Entity("BookStoreWebAPI.API.Models.Domain.Book", b =>
                {
                    b.HasOne("BookStoreWebAPI.API.Models.Domain.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreWebAPI.API.Models.Domain.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}

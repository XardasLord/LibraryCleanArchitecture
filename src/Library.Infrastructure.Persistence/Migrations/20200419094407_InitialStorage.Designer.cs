﻿// <auto-generated />
using System;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20200419094407_InitialStorage")]
    partial class InitialStorage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Domain.AggregateModels.LibraryUserAggregate.LibraryUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("LibraryUserId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LibraryUser");
                });

            modelBuilder.Entity("Library.Domain.AggregateModels.StorageAggregate.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BookId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("InStock")
                        .HasColumnName("InStock")
                        .HasColumnType("bit");

                    b.Property<long?>("StorageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Library.Domain.AggregateModels.StorageAggregate.Storage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Storage");

                    b.HasData(
                        new
                        {
                            Id = 1L
                        });
                });

            modelBuilder.Entity("Library.Domain.AggregateModels.LibraryUserAggregate.LibraryUser", b =>
                {
                    b.OwnsOne("Library.Domain.AggregateModels.LibraryUserAggregate.Email", "Email", b1 =>
                        {
                            b1.Property<long>("LibraryUserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LibraryUserId");

                            b1.ToTable("LibraryUser");

                            b1.WithOwner()
                                .HasForeignKey("LibraryUserId");
                        });
                });

            modelBuilder.Entity("Library.Domain.AggregateModels.StorageAggregate.Book", b =>
                {
                    b.HasOne("Library.Domain.AggregateModels.StorageAggregate.Storage", null)
                        .WithMany("Books")
                        .HasForeignKey("StorageId");

                    b.OwnsOne("Library.Domain.AggregateModels.StorageAggregate.BookInformation", "BookInformation", b1 =>
                        {
                            b1.Property<long>("BookId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Author")
                                .IsRequired()
                                .HasColumnName("Author")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Subject")
                                .IsRequired()
                                .HasColumnName("Subject")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnName("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BookId");

                            b1.ToTable("Book");

                            b1.WithOwner()
                                .HasForeignKey("BookId");

                            b1.OwnsOne("Library.Domain.AggregateModels.StorageAggregate.Isbn", "Isbn", b2 =>
                                {
                                    b2.Property<long>("BookInformationBookId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasColumnName("Isbn")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("BookInformationBookId");

                                    b2.ToTable("Book");

                                    b2.WithOwner()
                                        .HasForeignKey("BookInformationBookId");
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crud_dotnet_api.Data;

#nullable disable

namespace crud_dotnet_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240826203559_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("crud_dotnet_api.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Malcolm Gladwell",
                            PublishYear = "2000",
                            Title = "The Tipping Point"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Nicola Barker",
                            PublishYear = "2007",
                            Title = "Darkmans"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Helen Dunmore",
                            PublishYear = "2001",
                            Title = "The Siege"
                        },
                        new
                        {
                            Id = 4,
                            Author = "M John Harrison",
                            PublishYear = "2002",
                            Title = "Light"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Jenny Erpenbeck",
                            PublishYear = "2008",
                            Title = "Visitation"
                        });
                });

            modelBuilder.Entity("crud_dotnet_api.Data.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Benjamin Disraeli",
                            Content = "Det finns ingen bättre utbildning än motgångar."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Gustaf Lindborg",
                            Content = "Sjömannen ber inte om medvind, han lär sig segla."
                        },
                        new
                        {
                            Id = 3,
                            Author = "Jonathan Saffran Foer",
                            Content = "Du kan inte skydda dig själv från sorg utan att skydda dig själv från lycka."
                        },
                        new
                        {
                            Id = 4,
                            Author = "Mignon McLaughlin",
                            Content = "Mod kan inte se runt hörn, men går runt dem ändå."
                        },
                        new
                        {
                            Id = 5,
                            Author = "Philip Sidney",
                            Content = "Antingen så hittar jag en väg, eller så skapar jag en."
                        });
                });

            modelBuilder.Entity("crud_dotnet_api.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

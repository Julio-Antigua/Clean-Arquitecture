﻿// <auto-generated />
using CleanArquitecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArquitecture.Data.Migrations
{
    [DbContext(typeof(StreamerDbContext))]
    [Migration("20230221160903_MigracionInicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CleanArquitecture.Domain.Streamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("streamers");
                });

            modelBuilder.Entity("CleanArquitecture.Domain.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreamerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreamerId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("CleanArquitecture.Domain.Video", b =>
                {
                    b.HasOne("CleanArquitecture.Domain.Streamer", "Streamer")
                        .WithMany()
                        .HasForeignKey("StreamerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streamer");
                });
#pragma warning restore 612, 618
        }
    }
}

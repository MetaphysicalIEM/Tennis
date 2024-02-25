﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tennis.DAL.DataContext;

#nullable disable

namespace Tennis.DAL.Migrations
{
    [DbContext(typeof(TennisDbContext))]
    [Migration("20240225084610_AddVictoryDefeatPlayer")]
    partial class AddVictoryDefeatPlayer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tennis.DAL.Entities.GameOutcomeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEndGame")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStartGame")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdLoser")
                        .HasColumnType("integer");

                    b.Property<int>("IdWinner")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdLoser");

                    b.HasIndex("IdWinner");

                    b.ToTable("GameOutComes");
                });

            modelBuilder.Entity("Tennis.DAL.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DefeatNumber")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("VictoryNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Tennis.DAL.Entities.GameOutcomeEntity", b =>
                {
                    b.HasOne("Tennis.DAL.Entities.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("IdLoser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tennis.DAL.Entities.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("IdWinner")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

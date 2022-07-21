﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectEntra21.Infrastructure;

namespace ProjectEntra21.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220721020012_Employeer")]
    partial class Employeer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProjectEntra21.Domain.Entiteis.Employeer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Document")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LevelEmployeer")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Office")
                        .HasColumnType("longtext");

                    b.Property<long>("Register")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Employeers");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectEntra21.src.Infrastructure;

namespace ProjectEntra21.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220905223859_modificado10")]
    partial class modificado10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.Cell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("CodeCell")
                        .HasColumnType("bigint")
                        .HasColumnName("codigo_celula");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(8864))
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(9147))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<int>("StatusCell")
                        .HasColumnType("int")
                        .HasColumnName("status_celula");

                    b.HasKey("Id");

                    b.HasAlternateKey("CodeCell");

                    b.ToTable("Celula");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.CellEmployeer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CellId")
                        .HasColumnType("bigint");

                    b.Property<long>("Code")
                        .HasColumnType("bigint")
                        .HasColumnName("codigo");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9091))
                        .HasColumnName("criado_em");

                    b.Property<long?>("EmployeerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9371))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<int>("Phase")
                        .HasColumnType("int")
                        .HasColumnName("Fase");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("CellId");

                    b.HasIndex("EmployeerId");

                    b.ToTable("CelulaFuncionario");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.Employeer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("data_nascimento");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 859, DateTimeKind.Local).AddTicks(3499))
                        .HasColumnName("criado_em");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("documento");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 863, DateTimeKind.Local).AddTicks(2826))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<int>("LevelEmployeer")
                        .HasColumnType("int")
                        .HasColumnName("nivel_funcionario");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("funcao");

                    b.Property<long>("Register")
                        .HasColumnType("bigint")
                        .HasColumnName("matricula");

                    b.HasKey("Id");

                    b.HasAlternateKey("Register");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<int>("AmountEnter")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_entrada");

                    b.Property<int?>("AmountFinished")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_saida");

                    b.Property<long?>("CellEmployeerId")
                        .HasColumnType("bigint");

                    b.Property<long>("Code")
                        .HasColumnType("bigint")
                        .HasColumnName("codigo_ordem");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(659))
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(985))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("CellEmployeerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Ordem");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("Code")
                        .HasColumnType("bigint")
                        .HasColumnName("codigo_produto");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(83))
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(380))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_produto");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("tipo_produto");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.TotalPartial", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CellId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 873, DateTimeKind.Local).AddTicks(3155))
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("LastModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 9, 5, 19, 38, 58, 873, DateTimeKind.Local).AddTicks(3450))
                        .HasColumnName("ultima_modificao_em");

                    b.Property<int>("Phase")
                        .HasColumnType("int")
                        .HasColumnName("fase");

                    b.Property<int>("Total")
                        .HasColumnType("int")
                        .HasColumnName("total_saida");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("TotalParcial");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.CellEmployeer", b =>
                {
                    b.HasOne("ProjectEntra21.src.Domain.Entiteis.Cell", "Cell")
                        .WithMany()
                        .HasForeignKey("CellId");

                    b.HasOne("ProjectEntra21.src.Domain.Entiteis.Employeer", "Employeer")
                        .WithMany()
                        .HasForeignKey("EmployeerId");

                    b.Navigation("Cell");

                    b.Navigation("Employeer");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.Order", b =>
                {
                    b.HasOne("ProjectEntra21.src.Domain.Entiteis.CellEmployeer", "CellEmployeer")
                        .WithMany()
                        .HasForeignKey("CellEmployeerId");

                    b.HasOne("ProjectEntra21.src.Domain.Entiteis.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("CellEmployeer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjectEntra21.src.Domain.Entiteis.TotalPartial", b =>
                {
                    b.HasOne("ProjectEntra21.src.Domain.Entiteis.Cell", "Cell")
                        .WithMany()
                        .HasForeignKey("CellId");

                    b.Navigation("Cell");
                });
#pragma warning restore 612, 618
        }
    }
}
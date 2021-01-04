﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using generico.Models;

namespace walletCare.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    [Migration("20201231203654_Empezando3")]
    partial class Empezando3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("generico.Models.Ingreso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Aporte")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("generico.Models.Usuario", b =>
                {
                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreDeUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Mail");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactsAPI.Migrations
{
    [DbContext(typeof(ContactsAPIDbContext))]
    partial class ContactsAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContactsAPI.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityName = "Bahia Blanca",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 2,
                            CityName = "Punta Alta",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 3,
                            CityName = "Medanos",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 4,
                            CityName = "La Boca",
                            StateID = 2
                        },
                        new
                        {
                            CityID = 5,
                            CityName = "Balvanera",
                            StateID = 2
                        },
                        new
                        {
                            CityID = 6,
                            CityName = "Caballito",
                            StateID = 2
                        },
                        new
                        {
                            CityID = 7,
                            CityName = "Villa Crespo",
                            StateID = 2
                        },
                        new
                        {
                            CityID = 8,
                            CityName = "Monte Hermoso",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 9,
                            CityName = "La Matanza",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 10,
                            CityName = "Mar del Plata",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 11,
                            CityName = "Córdoba",
                            StateID = 3
                        },
                        new
                        {
                            CityID = 12,
                            CityName = "Villa General Belgrano",
                            StateID = 3
                        },
                        new
                        {
                            CityID = 13,
                            CityName = "Pigüé",
                            StateID = 1
                        },
                        new
                        {
                            CityID = 14,
                            CityName = "Villa Iris",
                            StateID = 1
                        });
                });

            modelBuilder.Entity("ContactsAPI.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactID = new Guid("4f01ed59-e0f3-4ac2-b688-79d759183ebb"),
                            CityID = 1,
                            ContactAddress = "DIRECCION 2",
                            ContactName = "NOMBRE 2",
                            ContactPhone = "1141112222"
                        },
                        new
                        {
                            ContactID = new Guid("fb37d4b7-caeb-4ffd-8824-876bf0993447"),
                            CityID = 4,
                            ContactAddress = "DIRECCION 4",
                            ContactName = "PRUEBA 4",
                            ContactPhone = "2233334444"
                        },
                        new
                        {
                            ContactID = new Guid("bc21a495-9c03-4e9c-8558-acead3d92085"),
                            CityID = 2,
                            ContactAddress = "DIRECCION 3",
                            ContactName = "PRUEBA 3",
                            ContactPhone = "2253334444"
                        },
                        new
                        {
                            ContactID = new Guid("27fd0b27-465b-43af-929e-e0a2c33ddcb5"),
                            CityID = 1,
                            ContactAddress = "DIRECCION 5",
                            ContactName = "PRUEBA 5",
                            ContactPhone = "1155556666"
                        });
                });

            modelBuilder.Entity("ContactsAPI.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"), 1L, 1);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateID = 1,
                            StateName = "Buenos Aires"
                        },
                        new
                        {
                            StateID = 2,
                            StateName = "Ciudad Autonoma de Buenos Aires"
                        },
                        new
                        {
                            StateID = 3,
                            StateName = "Catamarca"
                        },
                        new
                        {
                            StateID = 4,
                            StateName = "Chaco"
                        },
                        new
                        {
                            StateID = 5,
                            StateName = "Chubut"
                        },
                        new
                        {
                            StateID = 6,
                            StateName = "Cordoba"
                        },
                        new
                        {
                            StateID = 7,
                            StateName = "Corrientes"
                        },
                        new
                        {
                            StateID = 8,
                            StateName = "Entre Rios"
                        },
                        new
                        {
                            StateID = 9,
                            StateName = "Formosa"
                        },
                        new
                        {
                            StateID = 10,
                            StateName = "Jujuy"
                        },
                        new
                        {
                            StateID = 11,
                            StateName = "La Pampa"
                        },
                        new
                        {
                            StateID = 12,
                            StateName = "La Rioja"
                        },
                        new
                        {
                            StateID = 13,
                            StateName = "Mendoza"
                        },
                        new
                        {
                            StateID = 14,
                            StateName = "Misiones"
                        },
                        new
                        {
                            StateID = 15,
                            StateName = "Neuquen"
                        },
                        new
                        {
                            StateID = 16,
                            StateName = "Rio Negro"
                        },
                        new
                        {
                            StateID = 17,
                            StateName = "Salta"
                        },
                        new
                        {
                            StateID = 18,
                            StateName = "San Juan"
                        },
                        new
                        {
                            StateID = 19,
                            StateName = "San Luis"
                        },
                        new
                        {
                            StateID = 20,
                            StateName = "Santa Cruz"
                        },
                        new
                        {
                            StateID = 21,
                            StateName = "Santa Fe"
                        },
                        new
                        {
                            StateID = 22,
                            StateName = "Santiago del Estero"
                        },
                        new
                        {
                            StateID = 23,
                            StateName = "Tierra del Fuego"
                        },
                        new
                        {
                            StateID = 24,
                            StateName = "Tucuman"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("ContactsAPI.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StateID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ContactsAPI.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactsAPI.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

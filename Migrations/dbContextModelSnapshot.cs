﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace rubinetti.alessandro._5i.primaWeb.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Prenotazione", b =>
                {
                    b.Property<int?>("PrenotazioneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("dataNascita")
                        .HasColumnType("TEXT");

                    b.Property<string>("ruolo")
                        .HasColumnType("TEXT");

                    b.Property<string>("sesso")
                        .HasColumnType("TEXT");

                    b.HasKey("PrenotazioneId");

                    b.ToTable("Prenotaziones");
                });

            modelBuilder.Entity("Prodotti", b =>
                {
                    b.Property<int?>("ProdottiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quantita")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProdottiId");

                    b.ToTable("Prodottis");
                });
#pragma warning restore 612, 618
        }
    }
}

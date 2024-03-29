﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rubinetti.alessandro._5i.primaWeb.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotaziones",
                columns: table => new
                {
                    PrenotazioneId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    dataNascita = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    sesso = table.Column<string>(type: "TEXT", nullable: true),
                    ruolo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotaziones", x => x.PrenotazioneId);
                });

            migrationBuilder.CreateTable(
                name: "Prodottis",
                columns: table => new
                {
                    ProdottiId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodottis", x => x.ProdottiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotaziones");

            migrationBuilder.DropTable(
                name: "Prodottis");
        }
    }
}

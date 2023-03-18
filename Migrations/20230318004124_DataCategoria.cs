using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repaso1.Migrations
{
    /// <inheritdoc />
    public partial class DataCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("2109c605-8b39-4004-8650-26284c471ea1"), "Nada que hacer", "Activdades Personales", 10 },
                    { new Guid("2109c605-8b39-4004-8650-26284c471ea3"), "Nada que hacer", "Activdades Laborales", 30 },
                    { new Guid("2109c605-8b39-4004-8650-26284c471ea7"), "Nada que hacer", "Activdades Academicas", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2109c605-8b39-4004-8650-26284c471ea1"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2109c605-8b39-4004-8650-26284c471ea3"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2109c605-8b39-4004-8650-26284c471ea7"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaAutoGlass.Data.Migrations
{
    /// <inheritdoc />
    public partial class PruebaAutoGlassLeonardo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Proveedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Proveedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Productos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductoProveedor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductoProveedor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductoProveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ProductoProveedor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ProductoProveedor",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductoProveedor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductoProveedor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductoProveedor");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ProductoProveedor");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ProductoProveedor");
        }
    }
}

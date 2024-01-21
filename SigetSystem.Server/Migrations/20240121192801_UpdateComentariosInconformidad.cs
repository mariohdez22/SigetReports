using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigetSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComentariosInconformidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigos",
                table: "ComentariosInconformidads");

            migrationBuilder.RenameColumn(
                name: "IdCodigoInconformidad",
                table: "ComentariosInconformidads",
                newName: "IdComentarioInconformidad");

            migrationBuilder.AddColumn<string>(
                name: "ComentarioInconformidad",
                table: "ComentariosInconformidads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaComentario",
                table: "ComentariosInconformidads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioInconformidad",
                table: "ComentariosInconformidads");

            migrationBuilder.DropColumn(
                name: "FechaComentario",
                table: "ComentariosInconformidads");

            migrationBuilder.RenameColumn(
                name: "IdComentarioInconformidad",
                table: "ComentariosInconformidads",
                newName: "IdCodigoInconformidad");

            migrationBuilder.AddColumn<string>(
                name: "Codigos",
                table: "ComentariosInconformidads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigetSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ComentarioInconformidad",
                table: "ComentariosInconformidads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JobReportes",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReporteInspeccion = table.Column<int>(type: "int", nullable: false),
                    TokenJob = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReportes", x => x.IdJob);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobReportes");

            migrationBuilder.AlterColumn<string>(
                name: "ComentarioInconformidad",
                table: "ComentariosInconformidads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

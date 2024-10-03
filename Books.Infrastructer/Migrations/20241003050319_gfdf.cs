using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infrastructer.Migrations
{
    /// <inheritdoc />
    public partial class gfdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "BookModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookModel");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "BookModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "ISBN");
        }
    }
}

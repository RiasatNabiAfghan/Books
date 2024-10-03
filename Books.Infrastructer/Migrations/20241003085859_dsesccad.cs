using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infrastructer.Migrations
{
    /// <inheritdoc />
    public partial class dsesccad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "BookModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "BookModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

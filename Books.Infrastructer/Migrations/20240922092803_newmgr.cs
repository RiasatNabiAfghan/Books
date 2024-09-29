using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infrastructer.Migrations
{
    /// <inheritdoc />
    public partial class newmgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

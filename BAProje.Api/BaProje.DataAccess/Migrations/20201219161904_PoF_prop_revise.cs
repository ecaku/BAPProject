using Microsoft.EntityFrameworkCore.Migrations;

namespace BaProje.DataAccess.Migrations
{
    public partial class PoF_prop_revise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealProductId",
                table: "ProductOfCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealProductId",
                table: "ProductOfCart");
        }
    }
}

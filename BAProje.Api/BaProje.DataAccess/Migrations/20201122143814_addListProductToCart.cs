using Microsoft.EntityFrameworkCore.Migrations;

namespace BaProje.DataAccess.Migrations
{
    public partial class addListProductToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartId",
                table: "Product",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerName",
                table: "Customer",
                column: "CustomerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryName",
                table: "Category",
                column: "CategoryName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerName",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Email",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Product");
        }
    }
}

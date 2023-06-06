using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDemo.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryProductId",
                table: "Products",
                newName: "CategoryProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products",
                newName: "IX_Products_CategoryProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductID",
                table: "Products",
                column: "CategoryProductID",
                principalTable: "CategoryProducts",
                principalColumn: "CategoryProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryProductID",
                table: "Products",
                newName: "CategoryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryProductID",
                table: "Products",
                newName: "IX_Products_CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "CategoryProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    public partial class customers_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAddress_TestUsers_UserId",
                table: "UsersAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersAddress",
                table: "UsersAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestUsers",
                table: "TestUsers");

            migrationBuilder.RenameTable(
                name: "UsersAddress",
                newName: "AppCustomerAddresses");

            migrationBuilder.RenameTable(
                name: "TestUsers",
                newName: "AppCustomers");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAddress_UserId",
                table: "AppCustomerAddresses",
                newName: "IX_AppCustomerAddresses_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppCustomers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomerAddresses",
                table: "AppCustomerAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomerAddresses_AppCustomers_UserId",
                table: "AppCustomerAddresses",
                column: "UserId",
                principalTable: "AppCustomers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomerAddresses_AppCustomers_UserId",
                table: "AppCustomerAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomerAddresses",
                table: "AppCustomerAddresses");

            migrationBuilder.RenameTable(
                name: "AppCustomers",
                newName: "TestUsers");

            migrationBuilder.RenameTable(
                name: "AppCustomerAddresses",
                newName: "UsersAddress");

            migrationBuilder.RenameIndex(
                name: "IX_AppCustomerAddresses_UserId",
                table: "UsersAddress",
                newName: "IX_UsersAddress_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TestUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestUsers",
                table: "TestUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersAddress",
                table: "UsersAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAddress_TestUsers_UserId",
                table: "UsersAddress",
                column: "UserId",
                principalTable: "TestUsers",
                principalColumn: "Id");
        }
    }
}

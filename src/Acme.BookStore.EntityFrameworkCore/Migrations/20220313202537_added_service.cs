using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    public partial class added_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomerAddressupdatees_AppCustomers_UserId",
                table: "AppCustomerAddresses");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomerAddresses_UserId",
                table: "AppCustomerAddresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppCustomerAddresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppCustomerAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomerAddresses_UserId",
                table: "AppCustomerAddresses",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomerAddresses_AppCustomers_UserId",
                table: "AppCustomerAddresses",
                column: "UserId",
                principalTable: "AppCustomers",
                principalColumn: "Id");
        }
    }
}

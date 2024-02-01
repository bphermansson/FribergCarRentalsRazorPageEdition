using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsCarRentals.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MorePasswords5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {






            migrationBuilder.AddColumn<int>(
                name: "UsersID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserID",
                table: "Bookings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Bookings",
                newName: "CustomerEmail");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserID",
                table: "Bookings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}

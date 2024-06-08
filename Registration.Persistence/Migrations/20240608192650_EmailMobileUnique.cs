using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Persistence.Migrations
{
    public partial class EmailMobileUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Account",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Account_MobileNumber",
                table: "Account",
                column: "MobileNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Account_Email",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "UQ_Account_MobileNumber",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

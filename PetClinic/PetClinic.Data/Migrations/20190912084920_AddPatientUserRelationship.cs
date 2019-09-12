using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinic.Data.Migrations
{
    public partial class AddPatientUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Patient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ApplicationUserID",
                table: "Patient",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_ApplicationUser_ApplicationUserID",
                table: "Patient",
                column: "ApplicationUserID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_ApplicationUser_ApplicationUserID",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ApplicationUserID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Patient");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinic.Data.Migrations
{
    public partial class AddedDiagnosisSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veterinarian",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarian", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    VeterinarianId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Veterinarian_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "Veterinarian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VeterinarianId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialization_Veterinarian_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "Veterinarian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_PatientId",
                table: "Diagnosis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_VeterinarianId",
                table: "Diagnosis",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_VeterinarianId",
                table: "Specialization",
                column: "VeterinarianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Veterinarian");
        }
    }
}

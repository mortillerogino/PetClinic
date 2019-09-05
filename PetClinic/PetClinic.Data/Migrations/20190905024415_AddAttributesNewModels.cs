using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinic.Data.Migrations
{
    public partial class AddAttributesNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Patients_PatientId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Veterinarian_VeterinarianId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialization_Veterinarian_VeterinarianId",
                table: "Specialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarian",
                table: "Veterinarian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis");

            migrationBuilder.RenameTable(
                name: "Veterinarian",
                newName: "Veterinarians");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "Specializations");

            migrationBuilder.RenameTable(
                name: "Diagnosis",
                newName: "Diagnoses");

            migrationBuilder.RenameIndex(
                name: "IX_Specialization_VeterinarianId",
                table: "Specializations",
                newName: "IX_Specializations_VeterinarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_VeterinarianId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_VeterinarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_PatientId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Veterinarians",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specializations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VeterinarianId",
                table: "Diagnoses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Diagnoses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarians",
                table: "Veterinarians",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Veterinarians_VeterinarianId",
                table: "Diagnoses",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Veterinarians_VeterinarianId",
                table: "Specializations",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Veterinarians_VeterinarianId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Veterinarians_VeterinarianId",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarians",
                table: "Veterinarians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses");

            migrationBuilder.RenameTable(
                name: "Veterinarians",
                newName: "Veterinarian");

            migrationBuilder.RenameTable(
                name: "Specializations",
                newName: "Specialization");

            migrationBuilder.RenameTable(
                name: "Diagnoses",
                newName: "Diagnosis");

            migrationBuilder.RenameIndex(
                name: "IX_Specializations_VeterinarianId",
                table: "Specialization",
                newName: "IX_Specialization_VeterinarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_VeterinarianId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_VeterinarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Veterinarian",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specialization",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "VeterinarianId",
                table: "Diagnosis",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Diagnosis",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarian",
                table: "Veterinarian",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Patients_PatientId",
                table: "Diagnosis",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Veterinarian_VeterinarianId",
                table: "Diagnosis",
                column: "VeterinarianId",
                principalTable: "Veterinarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialization_Veterinarian_VeterinarianId",
                table: "Specialization",
                column: "VeterinarianId",
                principalTable: "Veterinarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

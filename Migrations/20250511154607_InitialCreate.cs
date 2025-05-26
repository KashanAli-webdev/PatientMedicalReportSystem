using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientRecordCURDWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PatientName = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    PatientGender = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatientAge = table.Column<byte>(type: "NUMBER(3)", nullable: false),
                    PatientContact = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    BloodGroup = table.Column<string>(type: "NVARCHAR2(3)", maxLength: 3, nullable: false),
                    HepatitisType = table.Column<string>(type: "NVARCHAR2(3)", maxLength: 3, nullable: false),
                    CholesterolLevel = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    BloodPressure = table.Column<string>(type: "NVARCHAR2(7)", maxLength: 7, nullable: false),
                    SugarLevel = table.Column<string>(type: "NVARCHAR2(19)", maxLength: 19, nullable: false),
                    Allergies = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChronicDiseases = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MedicalHistory = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

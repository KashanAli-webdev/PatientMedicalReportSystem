using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientRecordCURDWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Addjusted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SugarLevel",
                table: "MedicalRecord",
                type: "NVARCHAR2(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(19)",
                oldMaxLength: 19);

            migrationBuilder.AlterColumn<string>(
                name: "HepatitisType",
                table: "MedicalRecord",
                type: "NVARCHAR2(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "MedicalRecord",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(7)",
                oldMaxLength: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SugarLevel",
                table: "MedicalRecord",
                type: "NVARCHAR2(19)",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<string>(
                name: "HepatitisType",
                table: "MedicalRecord",
                type: "NVARCHAR2(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "MedicalRecord",
                type: "NVARCHAR2(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(11)",
                oldMaxLength: 11);
        }
    }
}

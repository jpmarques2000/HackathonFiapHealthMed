using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.HealthMed.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isScheduled",
                table: "Schedule",
                type: "bit",
                nullable: false,
                defaultValueSql: "(0)",
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isScheduled",
                table: "Schedule",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "(0)");
        }
    }
}

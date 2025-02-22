using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestDrive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "TestDrive",
        columns: table => new
        {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
            IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
            IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
            Booked = table.Column<bool>(type: "bit", nullable: false),
            StartDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
            EndDate = table.Column<DateTime>(type: "DateTime2", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_TestDrive", x => x.Id);
            table.ForeignKey(
                      name: "FK_TestDrive_Cars",
                      column: x => x.Id,
                      principalTable: "Cars",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade

                      );
            table.ForeignKey(
                name: "FK_TestDrive_Clients",
                column: x => x.Id,
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TestDrive");

        }
    }
}

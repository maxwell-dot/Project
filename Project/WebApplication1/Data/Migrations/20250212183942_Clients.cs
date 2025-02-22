using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Clients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
          name: "Clients",
          columns: table => new
          {
              Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
              FirstName = table.Column<string>(type: "nvarchar(256)", nullable: false),
              LastName = table.Column<string>(type: "nvarchar(512)", nullable: false),
              Email = table.Column<string>(type: "nvarchar(512)", nullable: false),
              Phone = table.Column<string>(type: "nvarchar(512)", nullable: false)
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_Clients", x => x.Id);
          });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Clients");

        }
    }
}

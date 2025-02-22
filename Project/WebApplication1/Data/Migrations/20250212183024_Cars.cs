using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Cars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Cars",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                   Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                   Model = table.Column<string>(type: "nvarchar(512)", nullable: false),
                   Color = table.Column<string>(type: "nvarchar(512)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Cars", x => x.Id);
               });

            migrationBuilder.InsertData(
               table: "Cars",
               columnTypes: new string[] { "nvarchar(256)", "nvarchar(512)", "nvarchar(512)"},
               columns: new[] { "Name", "Model", "Color" },
               values: new object[,]
               {
                    { "BMW", "X5", "Black" },
                    { "Audi", "A4", "White" },
                    { "Volvo", "XC90", "Silver" },
                    { "Mercedes", "GLC", "Blue" },
                    { "Skoda", "Octavia", "Red" },
                    { "Toyota", "Corolla", "Green" }
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Cars");

        }
    }
}

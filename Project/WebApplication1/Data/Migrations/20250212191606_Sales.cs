using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
       name: "Sales",
       columns: table => new
       {
           Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
           IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
           IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
           TotalPayment = table.Column<int>(type: "int", nullable: false)

       },
       constraints: table =>
       {
           table.PrimaryKey("PK_Sales", x => x.Id);
           table.ForeignKey(
                     name: "FK_Sales_Cars",
                     column: x => x.IdCar,
                     principalTable: "Cars",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Cascade

                     );
           table.ForeignKey(
               name: "FK_Sales_Clients",
               column: x => x.IdClient,
               principalTable: "Clients",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);
       });
            // add new
            migrationBuilder.CreateIndex(
        name: "IX_Sales_IdCar",
        table: "Sales",
        column: "IdCar"
    );

            //        migrationBuilder.CreateIndex(
            //            name: "IX_Sales_IdClient",
            //            table: "Sales",
            //            column: "IdClient"
            //        );
            //        // end new
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Sales");

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTutoral.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    BillingAddressID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTBL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTBL_AddressTBL_AddressID",
                        column: x => x.AddressID,
                        principalTable: "AddressTBL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTBL_AddressTBL_BillingAddressID",
                        column: x => x.BillingAddressID,
                        principalTable: "AddressTBL",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AddressTBL",
                columns: new[] { "Id", "Address1", "Address2", "City", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Main st", "Apt 5", "NewCity", "Ohio", "43224" },
                    { 2, "123 Addres 2", "Apt 5", "NewCity", "Ohio", "43224" }
                });

            migrationBuilder.InsertData(
                table: "UserTBL",
                columns: new[] { "Id", "AddressID", "BillingAddressID", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 1, 1, 2, "John@noWay.com", "John", "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTBL_AddressID",
                table: "UserTBL",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTBL_BillingAddressID",
                table: "UserTBL",
                column: "BillingAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTBL_EmailAddress",
                table: "UserTBL",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTBL_LastName_FirstName",
                table: "UserTBL",
                columns: new[] { "LastName", "FirstName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTBL");

            migrationBuilder.DropTable(
                name: "AddressTBL");
        }
    }
}

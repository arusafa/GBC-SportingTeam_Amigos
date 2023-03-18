using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Team_Amigos.Migrations
{
    public partial class Assignment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Canada" },
                    { 2, "Iran" },
                    { 3, "Turkey" },
                    { 4, "France" },
                    { 5, "The United States" },
                    { 6, "Spain" },
                    { 7, "Portugal" },
                    { 8, "The United Kingdom" },
                    { 9, "Greece" },
                    { 10, "Colombia" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "Firstname", "Lastname", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "Bourret Ave", "Montreal", 1, "Safa.Aru@georgebrown.ca", "Safa", "Aru", "647-834-8928", "H3W 1L4", "Quebec" },
                    { 2, "446 Gilmour St", "Ottawa", 1, "Ebrahim.Safdari@georgebrown.ca", "Ebi", "Safdari", "6476-789-2035", "KP2 0R8", "Otario" },
                    { 3, "565 Lawrence Ave", "Toronto", 1, "Elham.Veisouei@georgebrown.ca", "Elham", "Veisouei", "647-876-6989", "M6A 1A5", "Ontario" },
                    { 4, "1190 W 12th Ave", "Vancouver", 1, "Hakan.Inel@georgebrown.ca", "Hakan", "Inel", "416-746-8900", "V6H 1L6", "British Columbia" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1111, "DFAFT10", "Draft Manager 1.0", 4.5, new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1112, "TEAM10", "Team Manager 1.0", 4.9900000000000002, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1113, "LEAG10", "League Scheduler Deluxe 1.0", 7.9900000000000002, new DateTime(2019, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1114, "DRAFT20", "Draft Manager 2.0", 5.9900000000000002, new DateTime(2020, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 3333, "Alison.Diaz@gmail.com", "Alison Diaz", "243-768-9102" },
                    { 3334, "Ali.Ahmad@gmail.com", "Ali Ahmad", "468-990-1002" },
                    { 3335, "Gina.Friori@gmail.com", "Gina Friori", "567-356-3829" },
                    { 3336, "Andrew.Wendt@gmail.com", "Andrew Wendt", "467-389-2349" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CloseDate", "CustomerId", "Description", "OpenDate", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 2221, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Program fails with error, unable to launch the program.", new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, 3333, "Error launching program" },
                    { 2222, new DateTime(2019, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Program fails with error, unable to open import data.", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1112, 3334, "Error importing data" },
                    { 2223, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Program fails with error code 510, unable to open database.", new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1113, 3335, "Could not install" },
                    { 2224, new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Program fails with error code 510, unable to open database.", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1114, 3336, "Could not install" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1111 },
                    { 2, 2, 1112 },
                    { 3, 3, 1113 },
                    { 4, 4, 1114 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomerId",
                table: "Registrations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

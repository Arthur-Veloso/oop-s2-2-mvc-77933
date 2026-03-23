using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace oop_s2_2_mvc_77933.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremisesId = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUps_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Premises",
                columns: new[] { "Id", "Address", "Name", "RiskRating", "Town" },
                values: new object[,]
                {
                    { 1, "Main St", "Cafe One", 0, "Dublin" },
                    { 2, "High St", "Burger Spot", 2, "Dublin" },
                    { 3, "Market St", "Pizza Place", 1, "Dublin" },
                    { 4, "River Rd", "Sushi Bar", 0, "Cork" },
                    { 5, "King St", "Steak House", 2, "Cork" },
                    { 6, "Green St", "Vegan Hub", 1, "Cork" },
                    { 7, "Ocean Rd", "Taco Town", 0, "Galway" },
                    { 8, "Hill St", "BBQ Grill", 2, "Galway" },
                    { 9, "Bridge St", "Pasta Corner", 1, "Galway" },
                    { 10, "Sunset Blvd", "Bakery Bliss", 0, "Dublin" },
                    { 11, "Central Ave", "Coffee Express", 1, "Cork" },
                    { 12, "Station Rd", "Fast Bites", 2, "Galway" }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "InspectionDate", "Notes", "Outcome", "PremisesId", "Score" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, 90 },
                    { 2, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, 45 },
                    { 3, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3, 75 },
                    { 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 4, 88 },
                    { 5, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 5, 50 },
                    { 6, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 6, 70 },
                    { 7, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 7, 95 },
                    { 8, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 8, 30 },
                    { 9, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 9, 65 },
                    { 10, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 10, 85 },
                    { 11, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 11, 55 },
                    { 12, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 12, 60 },
                    { 13, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, 92 },
                    { 14, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, 40 },
                    { 15, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3, 78 },
                    { 16, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 4, 80 },
                    { 17, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 5, 35 },
                    { 18, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 6, 72 },
                    { 19, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 7, 88 },
                    { 20, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 8, 25 },
                    { 21, new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 9, 68 },
                    { 22, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 10, 90 },
                    { 23, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 11, 50 },
                    { 24, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 12, 62 },
                    { 25, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, 93 }
                });

            migrationBuilder.InsertData(
                table: "FollowUps",
                columns: new[] { "Id", "ClosedDate", "DueDate", "InspectionId", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 2, null, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 },
                    { 3, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 4, null, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 0 },
                    { 5, null, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 0 },
                    { 6, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 1 },
                    { 7, null, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0 },
                    { 8, null, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 0 },
                    { 9, null, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 10, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUps_InspectionId",
                table: "FollowUps",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PremisesId",
                table: "Inspections",
                column: "PremisesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FollowUps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Premises");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageEnterprises.Infrastructure.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Password = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    OwnEnterprise = table.Column<bool>(nullable: false, defaultValue: false),
                    Photo = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    Shares = table.Column<int>(nullable: false, defaultValue: 0),
                    SharePrice = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    OwnShares = table.Column<int>(nullable: false, defaultValue: 0),
                    City = table.Column<string>(maxLength: 150, nullable: false),
                    Country = table.Column<string>(maxLength: 150, nullable: false),
                    EnterpriseTypeId = table.Column<byte>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprises_EnterpriseTypes_EnterpriseTypeId",
                        column: x => x.EnterpriseTypeId,
                        principalTable: "EnterpriseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    City = table.Column<string>(maxLength: 150, nullable: false),
                    Country = table.Column<string>(maxLength: 150, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValue: 0m),
                    Photo = table.Column<string>(nullable: true),
                    PortfolioValue = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    FirstAccess = table.Column<bool>(nullable: false, defaultValue: true),
                    SuperAngel = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    InvestorId = table.Column<long>(nullable: false),
                    EnterpriseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.InvestorId, x.EnterpriseId });
                    table.ForeignKey(
                        name: "FK_Portfolios_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Portfolios_Investors_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_EnterpriseTypeId",
                table: "Enterprises",
                column: "EnterpriseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_UserId",
                table: "Enterprises",
                column: "UserId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseTypes_Name",
                table: "EnterpriseTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investors_UserId",
                table: "Investors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_EnterpriseId",
                table: "Portfolios",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropTable(
                name: "EnterpriseTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

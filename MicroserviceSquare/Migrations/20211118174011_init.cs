using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroserviceSquare.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delegations",
                columns: table => new
                {
                    DelegationId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delegations", x => x.DelegationId);
                });

            migrationBuilder.CreateTable(
                name: "TypeLanes",
                columns: table => new
                {
                    TypeLaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLanes", x => x.TypeLaneId);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    SquareId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelegationId = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.SquareId);
                    table.ForeignKey(
                        name: "FK_Squares_Delegations_DelegationId",
                        column: x => x.DelegationId,
                        principalTable: "Delegations",
                        principalColumn: "DelegationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SquareId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Squares_SquareId",
                        column: x => x.SquareId,
                        principalTable: "Squares",
                        principalColumn: "SquareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lanes",
                columns: table => new
                {
                    LaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberProvider = table.Column<int>(type: "int", nullable: false),
                    NumberGea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeLaneId = table.Column<int>(type: "int", nullable: false),
                    SquareId = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanes", x => x.LaneId);
                    table.ForeignKey(
                        name: "FK_Lanes_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                    table.ForeignKey(
                        name: "FK_Lanes_Squares_SquareId",
                        column: x => x.SquareId,
                        principalTable: "Squares",
                        principalColumn: "SquareId");
                    table.ForeignKey(
                        name: "FK_Lanes_TypeLanes_TypeLaneId",
                        column: x => x.TypeLaneId,
                        principalTable: "TypeLanes",
                        principalColumn: "TypeLaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanes_SectionId",
                table: "Lanes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lanes_SquareId",
                table: "Lanes",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Lanes_TypeLaneId",
                table: "Lanes",
                column: "TypeLaneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SquareId",
                table: "Sections",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_DelegationId",
                table: "Squares",
                column: "DelegationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lanes");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "TypeLanes");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "Delegations");
        }
    }
}

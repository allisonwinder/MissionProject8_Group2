using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission8_Group2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MatrixId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: true),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MatrixId);
                    table.ForeignKey(
                        name: "FK_responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Urgent/Important" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Urgent/Unimportant" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Not Urgent/Important" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Not Urgent/Unimportant" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MatrixId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, 1, true, "Tomorrow", 1, "Vacuuming the lawn" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MatrixId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 2, 2, false, "2/24/23", 2, "Study for IS 404 Test" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MatrixId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 4, 4, true, "Erry Day", 4, "Play Minecraft" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryId",
                table: "responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

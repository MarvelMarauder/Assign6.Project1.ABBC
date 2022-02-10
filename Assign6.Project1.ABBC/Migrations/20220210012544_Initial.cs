using Microsoft.EntityFrameworkCore.Migrations;

namespace Assign6.Project1.ABBC.Migrations
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
                name: "EffectiveTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectiveTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_EffectiveTasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "EffectiveTasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, 2, true, "Feb 9", (byte)1, "Add Models" });

            migrationBuilder.InsertData(
                table: "EffectiveTasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 2, 2, true, "Feb 9", (byte)1, "Add Views" });

            migrationBuilder.InsertData(
                table: "EffectiveTasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 3, 2, true, "Feb 9", (byte)1, "Add Quadrant View" });

            migrationBuilder.CreateIndex(
                name: "IX_EffectiveTasks_CategoryId",
                table: "EffectiveTasks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EffectiveTasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

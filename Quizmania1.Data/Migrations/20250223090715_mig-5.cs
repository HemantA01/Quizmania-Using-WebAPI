using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizmania1.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblQuizQuestionMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategpryId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Answer = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuizQuestionMaster", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblQuizQuestionMaster");
        }
    }
}

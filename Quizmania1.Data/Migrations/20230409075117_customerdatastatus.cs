﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizmania1.Data.Migrations
{
    /// <inheritdoc />
    public partial class customerdatastatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblDemoCustomerData_A",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblDemoCustomerData_A");
        }
    }
}

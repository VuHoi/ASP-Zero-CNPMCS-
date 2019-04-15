﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "AbpUsers");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.web.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FoodMenu",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FoodMenu");
        }
    }
}

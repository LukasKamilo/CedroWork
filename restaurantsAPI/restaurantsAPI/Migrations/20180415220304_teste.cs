using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace restaurantsAPI.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Dish",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Dish",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace restaurantsAPI.Migrations
{
    public partial class Correcao_EF3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "Dish",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_RestaurantId1",
                table: "Dish",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId1",
                table: "Dish",
                column: "RestaurantId1",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId1",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_RestaurantId1",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Dish");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

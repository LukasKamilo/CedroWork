using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace restaurantsAPI.Migrations
{
    public partial class Correcao_EF4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId1",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_RestaurantId1",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Dish");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "Dish",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_RestaurantId1",
                table: "Dish",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Restaurant_RestaurantId1",
                table: "Dish",
                column: "RestaurantId1",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

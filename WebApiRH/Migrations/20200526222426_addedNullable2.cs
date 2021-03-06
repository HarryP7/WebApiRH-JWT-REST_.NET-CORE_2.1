﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addedNullable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "Advert",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "Advert",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArquitecture.Infrastructure.Migrations
{
    public partial class CleanArquitectureVaxi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VideosActors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VideosActors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VideosActors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VideosActors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VideosActors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Directors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Directors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Actors",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VideosActors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VideosActors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VideosActors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VideosActors");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VideosActors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Actors");
        }
    }
}

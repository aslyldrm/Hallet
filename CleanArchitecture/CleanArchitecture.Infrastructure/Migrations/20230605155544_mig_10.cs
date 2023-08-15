using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class mig_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "JobRejectedRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "JobDoerRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ImageFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobRejectedRequest",
                table: "JobRejectedRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobDoerRequest",
                table: "JobDoerRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobRejectedRequest",
                table: "JobRejectedRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobDoerRequest",
                table: "JobDoerRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCategory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobRejectedRequest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobDoerRequest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Category");
        }
    }
}

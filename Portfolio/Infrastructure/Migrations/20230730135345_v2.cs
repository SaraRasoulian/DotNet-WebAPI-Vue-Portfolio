using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5b541c1f-85db-40d2-ab7e-4be9aff17c68"));

            migrationBuilder.DeleteData(
                table: "SEOSettings",
                keyColumn: "Id",
                keyValue: new Guid("654f025d-6e81-4e2a-ae19-d0fc16cb6e8b"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SEOSettings");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "SEOSettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Educations");

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "About", "CreatedAt", "Email", "FirstName", "Headline", "LastName", "LastUpdatedAt", "Photo" },
                values: new object[] { new Guid("1a5b9710-5e3c-4e4e-89df-0fc18eb82722"), "In publishing and graphic design, Lorem ipsum is a placeholder text.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Example@gmail.com", "Sara", "My name is Sara", "Rasoulian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "SEOSettings",
                columns: new[] { "Id", "CreatedAt", "Favicon", "LastUpdatedAt", "MetaAuthor", "MetaDescription", "MetaKeywords", "WebSiteTitle" },
                values: new object[] { new Guid("2f35406a-fccf-4ee4-a993-44d7eb0d3b4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "Sara Rasoulian | Portfolio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1a5b9710-5e3c-4e4e-89df-0fc18eb82722"));

            migrationBuilder.DeleteData(
                table: "SEOSettings",
                keyColumn: "Id",
                keyValue: new Guid("2f35406a-fccf-4ee4-a993-44d7eb0d3b4a"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SocialLinks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "SocialLinks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SEOSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "SEOSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Experiences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "Experiences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Educations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedBy",
                table: "Educations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "About", "CreatedAt", "CreatedBy", "Email", "FirstName", "Headline", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Photo" },
                values: new object[] { new Guid("5b541c1f-85db-40d2-ab7e-4be9aff17c68"), "In publishing and graphic design, Lorem ipsum is a placeholder text.", new DateTime(2023, 7, 27, 12, 28, 57, 960, DateTimeKind.Utc).AddTicks(4117), new Guid("48bb4dbf-142b-4e6d-8891-44f1b057789e"), "Example@gmail.com", "Sara", "My name is Sara", "Rasoulian", new DateTime(2023, 7, 27, 12, 28, 57, 960, DateTimeKind.Utc).AddTicks(4138), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "SEOSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Favicon", "LastUpdatedAt", "LastUpdatedBy", "MetaAuthor", "MetaDescription", "MetaKeywords", "WebSiteTitle" },
                values: new object[] { new Guid("654f025d-6e81-4e2a-ae19-d0fc16cb6e8b"), new DateTime(2023, 7, 27, 12, 28, 57, 960, DateTimeKind.Utc).AddTicks(4259), new Guid("898126ce-b606-4c37-9e9d-582a3d9d6238"), null, new DateTime(2023, 7, 27, 12, 28, 57, 960, DateTimeKind.Utc).AddTicks(4268), new Guid("00000000-0000-0000-0000-000000000000"), "", "", "", "Sara Rasoulian | Portfolio" });
        }
    }
}

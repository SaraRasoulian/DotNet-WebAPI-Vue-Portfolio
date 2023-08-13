using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Degree = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FieldOfStudy = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    School = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    StartYear = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    EndYear = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartYear = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    EndYear = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    Headline = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    About = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SEOSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WebSiteTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MetaAuthor = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    MetaKeywords = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Favicon = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEOSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    URL = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Icon = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "About", "Email", "FirstName", "Headline", "LastName", "Photo" },
                values: new object[] { new Guid("c1e9b646-34de-4e46-b6b1-4efb2f320578"), "In publishing and graphic design, Lorem ipsum is a placeholder text.", "Example@gmail.com", "Sara", "My name is Sara", "Rasoulian", null });

            migrationBuilder.InsertData(
                table: "SEOSettings",
                columns: new[] { "Id", "Favicon", "MetaAuthor", "MetaDescription", "MetaKeywords", "WebSiteTitle" },
                values: new object[] { new Guid("a10d6fdd-2744-4c5a-b47f-43e087811880"), null, null, null, null, "Sara Rasoulian | Portfolio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "SEOSettings");

            migrationBuilder.DropTable(
                name: "SocialLinks");
        }
    }
}

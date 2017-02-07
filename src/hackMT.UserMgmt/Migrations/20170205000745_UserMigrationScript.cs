using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hackMT.UserMgmt.Migrations
{
    public partial class UserMigrationScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    api_token = table.Column<string>(nullable: true),
                    avatar_url = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    new_password = table.Column<string>(nullable: true),
                    old_password = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

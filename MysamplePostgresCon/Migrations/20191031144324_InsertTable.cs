using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace MysamplePostgresCon.Migrations
{
    public partial class InsertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Posts.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

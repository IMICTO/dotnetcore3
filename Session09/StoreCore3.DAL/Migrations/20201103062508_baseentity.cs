using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreCore3.DAL.Migrations
{
    public partial class BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROC GetTeachers AS SELECT * FROM Teachers GO");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierUsername",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "TeacherCourses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierUsername",
                table: "TeacherCourses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "TeacherCourses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierUsername",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "StudentCourses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierUsername",
                table: "StudentCourses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "StudentCourses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierUsername",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC GetTeachers");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifierUsername",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "ModifierUsername",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifierUsername",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ModifierUsername",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifierUsername",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Courses");
        }
    }
}

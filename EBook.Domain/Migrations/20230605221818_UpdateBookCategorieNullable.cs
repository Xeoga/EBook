using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBook.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookCategorieNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookCategorieId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouse_PublishingHouseId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishingHouse",
                table: "PublishingHouse");

            migrationBuilder.RenameTable(
                name: "PublishingHouse",
                newName: "PublishingHouses");

            migrationBuilder.AlterColumn<int>(
                name: "PublishingHouseId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookCategorieId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishingHouses",
                table: "PublishingHouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookCategorieId",
                table: "Books",
                column: "BookCategorieId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookCategorieId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishingHouses",
                table: "PublishingHouses");

            migrationBuilder.RenameTable(
                name: "PublishingHouses",
                newName: "PublishingHouse");

            migrationBuilder.AlterColumn<int>(
                name: "PublishingHouseId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookCategorieId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishingHouse",
                table: "PublishingHouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookCategorieId",
                table: "Books",
                column: "BookCategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouse_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

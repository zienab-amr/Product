using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    /// <inheritdoc />
    public partial class AddTraineeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 1,
                column: "Image",
                value: "https://i.pravatar.cc/150?img=12");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 2,
                column: "Image",
                value: "https://i.pravatar.cc/150?img=47");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 3,
                column: "Image",
                value: "https://i.pravatar.cc/150?img=33");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Trainees");
        }
    }
}

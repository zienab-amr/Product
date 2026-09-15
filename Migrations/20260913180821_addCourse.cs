using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.Migrations
{
    /// <inheritdoc />
    public partial class addCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    CourseHours = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResults_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResults_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseHours", "Degree", "DepartmentId", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 60, 100, 1, 50, "C# Programming" },
                    { 2, 45, 100, 1, 50, "Database Systems" },
                    { 3, 60, 100, 1, 50, "Web Development" },
                    { 4, 45, 100, 2, 50, "System Analysis" },
                    { 5, 50, 100, 2, 50, "Business Intelligence" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { 3, "Artificial Intelligence" });

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 1,
                column: "Name",
                value: "Ahmed Hassan");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 2,
                column: "Name",
                value: "Zeinab Amr");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 3,
                column: "Name",
                value: "Omar Khaled");

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "TraineeId", "DepartmentId", "Image", "Name" },
                values: new object[] { 4, 2, "https://i.pravatar.cc/150?img=44", "Mariam Ali" });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 85, 1 },
                    { 2, 2, 78, 1 },
                    { 3, 3, 92, 1 },
                    { 4, 1, 95, 2 },
                    { 5, 2, 88, 2 },
                    { 6, 3, 91, 2 },
                    { 7, 4, 82, 3 },
                    { 8, 5, 76, 3 },
                    { 9, 4, 90, 4 },
                    { 10, 5, 87, 4 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseHours", "Degree", "DepartmentId", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 6, 60, 100, 3, 50, "Machine Learning" },
                    { 7, 60, 100, 3, 50, "Deep Learning" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Address", "DepartmentId", "Email", "Image", "Name", "PhoneNumber", "Salary" },
                values: new object[] { 4, "Cairo, Egypt", 3, "menna.adel@example.com", "https://i.pravatar.cc/150?img=49", "Dr. Menna Adel", "01098765432", 27000m });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "TraineeId", "DepartmentId", "Image", "Name" },
                values: new object[,]
                {
                    { 5, 3, "https://i.pravatar.cc/150?img=13", "Youssef Mohamed" },
                    { 6, 3, "https://i.pravatar.cc/150?img=32", "Salma Ahmed" }
                });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 11, 6, 94, 5 },
                    { 12, 7, 89, 5 },
                    { 13, 6, 86, 6 },
                    { 14, 7, 93, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_CourseId",
                table: "CourseResults",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResults");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "Image", "IsActive", "Name", "Price", "Rating", "Stock" },
                values: new object[,]
                {
                    { 1, "Vivo", "Smartphones", "Excellent smartphone with a high-resolution camera and great display.", "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=500", true, "Vivo V50 5G", 15000m, 5, 50 },
                    { 2, "Lenovo", "Laptops", "Durable and powerful laptop, perfect for programming and development.", "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?w=500", true, "Lenovo ThinkPad", 35000m, 4, 20 },
                    { 3, "Sony", "Accessories", "Noise-cancelling wireless earbuds with crystal clear sound.", "https://images.unsplash.com/photo-1590658268037-6bf12165a8df?w=500", true, "Sony Wireless Earbuds", 1200m, 4, 100 }
                });

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 1,
                column: "Name",
                value: "Ahmed");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 2,
                column: "Name",
                value: "Zeinab");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "TraineeId",
                keyValue: 3,
                column: "Name",
                value: "Omar");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "Image", "IsActive", "Name", "Price", "Rating", "Stock" },
                values: new object[,]
                {
                    { 1, "Vivo", "Smartphones", "Excellent smartphone with a high-resolution camera and great display.", "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=500", true, "Vivo V50 5G", 15000m, 5, 50 },
                    { 2, "Lenovo", "Laptops", "Durable and powerful laptop, perfect for programming and development.", "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?w=500", true, "Lenovo ThinkPad", 35000m, 4, 20 },
                    { 3, "Sony", "Accessories", "Noise-cancelling wireless earbuds with crystal clear sound.", "https://images.unsplash.com/photo-1590658268037-6bf12165a8df?w=500", true, "Sony Wireless Earbuds", 1200m, 4, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

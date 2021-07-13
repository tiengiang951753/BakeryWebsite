using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryProj.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Permission = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID_Cs = table.Column<int>(type: "INTEGER", nullable: false),
                    Name_Cs = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID_Od = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_Cs = table.Column<string>(type: "TEXT", nullable: true),
                    Name_Cs = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Total_Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Total_Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID_Od);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID_Od = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity_Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.Id, x.ID_Od });
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageFileName = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Item_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 1, "BK", "A scrumptious mini-carrot cake encrusted with sliced almonds", "carrot_cake.jpg", "Carrot Cake", 1500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 25, "BM", "Bánh được làm từ bột ngũ cốc, giàu chất xơ, hương vị thơm bùi. Bánh có hàm lượng chất xơ cao, phù hợp với người ăn kiêng, tiểu đường. Bánh cần được bảo quản ở nhiệt độ phòng, tránh ánh sáng trực tiếp từ mặt trời. Khi bánh chưa được sử dụng hết, Quý khách vui lòng bảo quản trong ngăn mát tủ lạnh.", "banhngucoc.jpg", "Bánh mì ngũ cốc", 39000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 24, "BM", "Bánh cà phê nhân đậu đỏ là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vịdậu đỏ và nho đen giòn, ngọt.", "banhcafe.jpg", "Bánh cà phê nhân đậu đỏ", 15000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 23, "BM", "Bánh sừng bò được xếp thành ngàn lớp, cuộn lại với nhau thành hình chiếc sừng bò ngộ nghĩnh. Mặt bánh phủ lớp vừng thêm phần thu hút.", "sungbomini.jpg", "Bánh sừng bò mini", 45000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 22, "BK", "Cốt bánh socola 4 lớp với lớp nhân mứt táo đặc biệt, lớp kem socola cùng với bàn tay khéo léo của người thợ đã tạo hình nên chiếc bánh kem hình mặt chú gấu vô cùng dễ thương và bắt mắt.", "teddy.jpg", "Bánh kem Teddy Bear", 280000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 21, "BK", "Bánh kem 3D Car với cốt bánh vanilla 4 lớp đặc biệt thêm lớp nhân kem vanilla phủ xung quanh thành hình chiếc ô tô đáng yêu cho bé tha hồ thỏa sức vui chơi. Bé sẽ tự tin khi được sở hữu chiếc bánh kem “cute” và sẽ có một buổi tiệc vui chơi thỏa thích cùng bạn bè", "3dcar.jpg", "Bánh kem 3D Car", 280000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 20, "BK", "Bánh kem Mango với cốt bánh vani 3 lớp đặc biệt bánh được phủ lên những lớp kem vani béo ngậy tạo độ cân bằng cho hương vị ngọt – béo. Sau cùng phủ lên lớp mứt xoài với hương vị chua đặc trưng và những thanh socola tạo cho khách hàng sự tận hưởng khó quên", "mango.jpg", "Bánh kem Mango", 200000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 19, "BK", "Bánh kem Puppy với cốt bánh vanilla, với nhân mứt việt quất bánh được trang trí hình chó con ngộ nghĩnh, đáng yêu dành cho những ai có tâm hồn “bay bổng” với mẫu bánh này.", "puppy.jpg", "Bánh kem Puppy", 200000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 18, "BK", "Bánh Boston Chocolate có cốt bánh socola 3 lớp nhân kem socola, mặt bánh phủ socola, trang trí macaron và socola bi", "boston.jpg", "Bánh kem Boston Chocolate", 350000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 17, "BV", "Cá hồi xông khói, nước cốt chanh, với kem phô mai cùng quế và nho khô, kèm phần khoai tây chiên", "bagel-salmon.jpg", "Bánh mì vòng kẹp cá hồi", 140000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 16, "BV", "Bánh bao gồm bánh mì kẹp có thịt bò xay ở giữa. Miếng thịt đã được nướng và thường được ăn với một số gia vị bên trong cùng với 2 miếng bánh mì hình tròn. Phần nhân bánh gồm thịt bò nướng, salad, cà chua, khoai tây chiên", "hamburger.jpg", "Hamburger bò", 15000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 15, "BV", "Bánh dẹt, tròn được chế biến từ nước, bột mỳ và nấm men, sau khi đã được ủ ít nhất 24 tiếng đồng hồ và nhào nặn thành loại bánh có hình dạng tròn và dẹt, và được cho vào lò nướng chín", "pizza-sea.jpg", "Bánh Pizza", 150000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 26, "BM", "Bánh mỳ baguette thơm ngon chuẩn Pháp. Vỏ bánh giòn, ruột mềm, thơm ngậy vị bơ", "baguette.jpg", "Bánh mì Baguette", 15000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 14, "BV", "Bánh donut sẽ được những người thợ tỉ mỉ tạo hình bánh tròn nhỏ, nướng giòn, sau đó phủ thêm một lớp socola cho những ai yêu thích hương vị ngọt", "chocolate-donut.jpg", "Donut Socola", 10000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 12, "BN", "Bánh nhân tart trứng mềm thơm, ngon miệng là sản phẩm được ưa chuộng bởi mọi lứa tuổi.", "egg-tart.jpg", "Bánh Tart Trứng", 15000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 11, "BN", "Bánh cà phê nhân nho đen là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vị cà phê và nho đen giòn, ngọt.", "coffee-cake.jpg", "Bánh Cà Phê Nhân Nho Đen", 15000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 10, "BN", "Bánh chuối được làm từ bột mỳ kết hợp cùng hương vị chuối ngọt ngào. Mỗi miếng bánh là một hương vị tuyệt vời mà bạn không thể bỏ lỡ", "opera-pie.jpg", "Bánh Miếng Dứa", 30000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 9, "BN", "Bánh chuối được làm từ bột mỳ kết hợp cùng hương vị chuối ngọt ngào. Mỗi miếng bánh là một hương vị tuyệt vời mà bạn không thể bỏ lỡ", "banana-pie.jpg", "Bánh Miếng Chuối", 30000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 8, "BN", "Tiramisu được phủ lên vị phomai kem béo ngậy, thêm vào đó là lớp bột cacao chất lượng tạo nên sự mềm mịn, mát lạnh tuyệt vời cho bánh", "tiramisu.jpg", "Tiramisu", 29000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 7, "BN", "Rich chocolate frosting cover this chocolate lover's dream", "chocolate_cake.jpg", "Chocolate Cake", 2500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 6, "BK", "Rich chocolate frosting cover this chocolate lover's dream", "chocolate_cake.jpg", "Chocolate Cake", 2500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 5, "BN", "A glazed pear tart topped with sliced almonds and a dash of cinnamon", "pear_tart.jpg", "Pear Tart", 1500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 4, "BN", "Fresh baked French-style bread", "bread.jpg", "Bread", 1500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 3, "BN", "Delectable vanilla and chocolate cupcakes", "cupcakes.jpg", "Cupcakes", 1500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 2, "BN", "A delicious lemon tart with fresh meringue cooked to perfection", "lemon_tart.jpg", "Lemon Tart", 1500m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 13, "BV", "Bánh mì vòng được phủ 1 lớp kem phô mai bên trên", "bagel-chesse.jpg", "Bánh mì vòng với kem phô mai", 10000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFileName", "Name", "Price", "Quantity" },
                values: new object[] { 27, "BM", "Bánh cà phê nhân nho đen là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vị cà phê và nho đen giòn, ngọt.", "cafenho.jpg", "Bánh cà phê nhân nho đen", 15000m, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProductId",
                table: "Item",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

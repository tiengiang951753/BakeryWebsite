using BakeryProj.Models;
using Microsoft.EntityFrameworkCore;
namespace BakeryProj.Data
{
    public static class ModelBuilderExtensions
    {
       public static ModelBuilder Seed(this ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Carrot Cake",
                    Description = "A scrumptious mini-carrot cake encrusted with sliced almonds",
                    Price = 1500m,
                    ImageName = "carrot_cake.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Lemon Tart",
                    Description = "A delicious lemon tart with fresh meringue cooked to perfection",
                    Price = 1500m,
                    ImageName = "lemon_tart.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 3,
                    Name = "Cupcakes",
                    Description = "Delectable vanilla and chocolate cupcakes",
                    Price = 1500m,
                    ImageName = "cupcakes.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 4,
                    Name = "Bread",
                    Description = "Fresh baked French-style bread",
                    Price = 1500m,
                    ImageName = "bread.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 5,
                    Name = "Pear Tart",
                    Description = "A glazed pear tart topped with sliced almonds and a dash of cinnamon",
                    Price = 1500m,
                    ImageName = "pear_tart.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 6,
                    Name = "Chocolate Cake",
                    Description = "Rich chocolate frosting cover this chocolate lover's dream",
                    Price = 2500m,
                    ImageName = "chocolate_cake.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 7,
                    Name = "Chocolate Cake",
                    Description = "Rich chocolate frosting cover this chocolate lover's dream",
                    Price = 2500m,
                    ImageName = "chocolate_cake.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 8,
                    Name = "Tiramisu",
                    Description = "Tiramisu được phủ lên vị phomai kem béo ngậy, thêm vào đó là lớp bột cacao chất lượng tạo nên sự mềm mịn, mát lạnh tuyệt vời cho bánh",
                    Price = 29000m,
                    ImageName = "tiramisu.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 9,
                    Name = "Bánh Miếng Chuối",
                    Description = "Bánh chuối được làm từ bột mỳ kết hợp cùng hương vị chuối ngọt ngào. Mỗi miếng bánh là một hương vị tuyệt vời mà bạn không thể bỏ lỡ",
                    Price = 30000m,
                    ImageName = "banana-pie.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 10,
                    Name = "Bánh Miếng Dứa",
                    Description = "Bánh chuối được làm từ bột mỳ kết hợp cùng hương vị chuối ngọt ngào. Mỗi miếng bánh là một hương vị tuyệt vời mà bạn không thể bỏ lỡ",
                    Price = 30000m,
                    ImageName = "opera-pie.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 11,
                    Name = "Bánh Cà Phê Nhân Nho Đen",
                    Description = "Bánh cà phê nhân nho đen là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vị cà phê và nho đen giòn, ngọt.",
                    Price = 15000m,
                    ImageName = "coffee-cake.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 12,
                    Name = "Bánh Tart Trứng",
                    Description = "Bánh nhân tart trứng mềm thơm, ngon miệng là sản phẩm được ưa chuộng bởi mọi lứa tuổi.",
                    Price = 15000m,
                    ImageName = "egg-tart.jpg",
                    Category = "BN",
                    Quantity = 10
                },
                new Product
                {
                    Id = 13,
                    Name = "Bánh mì vòng với kem phô mai",
                    Description = "Bánh mì vòng được phủ 1 lớp kem phô mai bên trên",
                    Price = 10000m,
                    ImageName = "bagel-chesse.jpg",
                    Category = "BV",
                    Quantity = 10
                },
                new Product
                {
                    Id = 14,
                    Name = "Donut Socola",
                    Description = "Bánh donut sẽ được những người thợ tỉ mỉ tạo hình bánh tròn nhỏ, nướng giòn, sau đó phủ thêm một lớp socola cho những ai yêu thích hương vị ngọt",
                    Price = 10000m,
                    ImageName = "chocolate-donut.jpg",
                    Category = "BV",
                    Quantity = 10
                },
                new Product
                {
                    Id = 15,
                    Name = "Bánh Pizza",
                    Description = "Bánh dẹt, tròn được chế biến từ nước, bột mỳ và nấm men, sau khi đã được ủ ít nhất 24 tiếng đồng hồ và nhào nặn thành loại bánh có hình dạng tròn và dẹt, và được cho vào lò nướng chín",
                    Price = 150000m,
                    ImageName = "pizza-sea.jpg",
                    Category = "BV",
                    Quantity = 10
                },
                new Product
                {
                    Id = 16,
                    Name = "Hamburger bò",
                    Description = "Bánh bao gồm bánh mì kẹp có thịt bò xay ở giữa. Miếng thịt đã được nướng và thường được ăn với một số gia vị bên trong cùng với 2 miếng bánh mì hình tròn. Phần nhân bánh gồm thịt bò nướng, salad, cà chua, khoai tây chiên",
                    Price = 15000m,
                    ImageName = "hamburger.jpg",
                    Category = "BV",
                    Quantity = 10
                },
                new Product
                {
                    Id = 17,
                    Name = "Bánh mì vòng kẹp cá hồi",
                    Description = "Cá hồi xông khói, nước cốt chanh, với kem phô mai cùng quế và nho khô, kèm phần khoai tây chiên",
                    Price = 140000m,
                    ImageName = "bagel-salmon.jpg",
                    Category = "BV",
                    Quantity = 10
                },
                new Product
                {
                    Id = 18,
                    Name = "Bánh kem Boston Chocolate",
                    Description = "Bánh Boston Chocolate có cốt bánh socola 3 lớp nhân kem socola, mặt bánh phủ socola, trang trí macaron và socola bi",
                    Price = 350000m,
                    ImageName = "boston.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 19,
                    Name = "Bánh kem Puppy",
                    Description = "Bánh kem Puppy với cốt bánh vanilla, với nhân mứt việt quất bánh được trang trí hình chó con ngộ nghĩnh, đáng yêu dành cho những ai có tâm hồn “bay bổng” với mẫu bánh này.",
                    Price = 200000m,
                    ImageName = "puppy.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 20,
                    Name = "Bánh kem Mango",
                    Description = "Bánh kem Mango với cốt bánh vani 3 lớp đặc biệt bánh được phủ lên những lớp kem vani béo ngậy tạo độ cân bằng cho hương vị ngọt – béo. Sau cùng phủ lên lớp mứt xoài với hương vị chua đặc trưng và những thanh socola tạo cho khách hàng sự tận hưởng khó quên",
                    Price = 200000m,
                    ImageName = "mango.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 21,
                    Name = "Bánh kem 3D Car",
                    Description = "Bánh kem 3D Car với cốt bánh vanilla 4 lớp đặc biệt thêm lớp nhân kem vanilla phủ xung quanh thành hình chiếc ô tô đáng yêu cho bé tha hồ thỏa sức vui chơi. Bé sẽ tự tin khi được sở hữu chiếc bánh kem “cute” và sẽ có một buổi tiệc vui chơi thỏa thích cùng bạn bè",
                    Price = 280000m,
                    ImageName = "3dcar.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 22,
                    Name = "Bánh kem Teddy Bear",
                    Description = "Cốt bánh socola 4 lớp với lớp nhân mứt táo đặc biệt, lớp kem socola cùng với bàn tay khéo léo của người thợ đã tạo hình nên chiếc bánh kem hình mặt chú gấu vô cùng dễ thương và bắt mắt.",
                    Price = 280000m,
                    ImageName = "teddy.jpg",
                    Category = "BK",
                    Quantity = 10
                },
                new Product
                {
                    Id = 23,
                    Name = "Bánh sừng bò mini",
                    Description = "Bánh sừng bò được xếp thành ngàn lớp, cuộn lại với nhau thành hình chiếc sừng bò ngộ nghĩnh. Mặt bánh phủ lớp vừng thêm phần thu hút.",
                    Price = 45000m,
                    ImageName = "sungbomini.jpg",
                    Category = "BM",
                    Quantity = 10
                },
                new Product
                {
                    Id = 24,
                    Name = "Bánh cà phê nhân đậu đỏ",
                    Description = "Bánh cà phê nhân đậu đỏ là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vịdậu đỏ và nho đen giòn, ngọt.",
                    Price = 15000m,
                    ImageName = "banhcafe.jpg",
                    Category = "BM",
                    Quantity = 10
                },
                new Product
                {
                    Id = 25,
                    Name = "Bánh mì ngũ cốc",
                    Description = "Bánh được làm từ bột ngũ cốc, giàu chất xơ, hương vị thơm bùi. Bánh có hàm lượng chất xơ cao, phù hợp với người ăn kiêng, tiểu đường. Bánh cần được bảo quản ở nhiệt độ phòng, tránh ánh sáng trực tiếp từ mặt trời. Khi bánh chưa được sử dụng hết, Quý khách vui lòng bảo quản trong ngăn mát tủ lạnh.",
                    Price = 39000m,
                    ImageName = "banhngucoc.jpg",
                    Category = "BM",
                    Quantity = 10
                },
                new Product
                {
                    Id = 26,
                    Name = "Bánh mì Baguette",
                    Description = "Bánh mỳ baguette thơm ngon chuẩn Pháp. Vỏ bánh giòn, ruột mềm, thơm ngậy vị bơ",
                    Price = 15000m,
                    ImageName = "baguette.jpg",
                    Category = "BM",
                    Quantity = 10
                },
                new Product
                {
                    Id = 27,
                    Name = "Bánh cà phê nhân nho đen",
                    Description = "Bánh cà phê nhân nho đen là sản phẩm đặc trưng theo phong cách của Mexico. Vỏ bánh mềm mịn, nhân bánh hương vị cà phê và nho đen giòn, ngọt.",
                    Price = 15000m,
                    ImageName = "cafenho.jpg",
                    Category = "BM",
                    Quantity = 10
                }
            );
            return modelBuilder;
        }
    } 
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    public partial class PopularProduct : Migration
    {
     
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Product(Name,Description,Price,ImageUrl,Stock,DateRegister,CategoryId) Values('omega3','O ômega-3 é um tipo de gordura saudável que faz bem para o nosso corpo.', 10.00, 'omega3.jpg',5,now(),1)");
            migrationBuilder.Sql("insert into Product(Name,Description,Price,ImageUrl,Stock,DateRegister,CategoryId) Values('cafeina','A cafeína é uma substância que nos mantém acordados e alertas.', 20.00, 'cafeina.jpg',10,now(),2)");
            migrationBuilder.Sql("insert into Product(Name,Description,Price,ImageUrl,Stock,DateRegister,CategoryId) Values('teanina','A teanina é um composto natural encontrado no chá que pode ajudar a relaxar e reduzir o estresse.', 25.00, 'teanina.jpg',2,now(),3)");


            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('memoria', 'memoria.jpg')");
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('estimulante', 'estimulante.jpg')");
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('calmante', 'calmante.jpg')");
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Product");

            migrationBuilder.Sql("Delete from Category");
        }
    }
}

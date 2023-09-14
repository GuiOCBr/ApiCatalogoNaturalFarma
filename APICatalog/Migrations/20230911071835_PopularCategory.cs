using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// usar os metodos Up e Down cria uma migração vazia para popular categorias 
    public partial class PopularCategory : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('Omega3', 'omega.jpg')");
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('Cafeina', 'cafeina.jpg')");
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values ('Teanina', 'teanina.jpg')");
        }
      
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Category");
        }
    }
}

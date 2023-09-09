
namespace Catalog.API.Models
{
    //? Anemic model 
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }


    }
}
namespace Catalog.API.Application.Dtos;
//? Data Transfer Object (DTO)
//? Immutable

    public class ProductForAddDto
    {
        public string Name {get; init;}
        public int Price {get; init;}
        public string Description{get; init;}

        public ProductForAddDto(string name , int price , string description){
            Name = name ;
            Price = price;
            Description = description;
        }






    }

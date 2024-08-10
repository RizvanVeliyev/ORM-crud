using ORM_crud.Exceptions;
using ORM_crud.Models;
using ORM_crud.Services;


ProductService productService = new ProductService();
CategoryService categoryservice = new CategoryService();
//Product product1 = new Product
//{
//    Name="Telefon",
//    Price=1000,
//    CategoryId=1
//};
//Product product2 = new Product
//{
//    Name = "Tv",
//    Price = 800,
//    CategoryId = 1
//};
//Product product3 = new Product
//{
//    Name = "Divar saati",
//    Price = 100,
//    CategoryId = 2
//};
//Product product4 = new Product
//{
//    Name = "Skaf",
//    Price = 150,
//    CategoryId = 2
//};
//Category category1 = new Category
//{
//    Name="Elektronika"
//};
//Category category2 = new Category
//{
//    Name = "Ev esyasi"
//};

//List<Product> products = await productService.GetAllAsync();
//foreach (Product item in products)
//{
//    Console.WriteLine($"Name:{item.Name} Price:{item.Price} Category:{item.Category.Name}");
//}

try
{
    var product = await productService.GetByIdAsync(6);
    Console.WriteLine($"Name:{product.Name} Price:{product.Price} Category:{product.Category.Name}");

}
catch (NotFoundException e)
{
    Console.WriteLine(e.Message);
}



try
{
    var product = await productService.GetByIdAsync(3);
    product.Name = "Xalca";
    productService.UpdateAsync(product);
    Console.WriteLine($"Name:{product.Name} Price:{product.Price} Category:{product.Category.Name}");

}
catch (NotFoundException e)
{
    Console.WriteLine(e.Message);
}


Product product1 = new Product
{
    Name = "Tozsoran",
    Price = 125,
    CategoryId = 1
};
productService.CreateAsync(product1);




try
{
    await productService.DeleteAsync(2);
    Console.WriteLine("Silindi!");
}
catch(NotFoundException e)
{
    Console.WriteLine(e.Message);
}
List<Product> products = await productService.GetAllAsync();
foreach (Product item in products)
{
    Console.WriteLine($"Name:{item.Name} Price:{item.Price} Category:{item.Category.Name}");
}

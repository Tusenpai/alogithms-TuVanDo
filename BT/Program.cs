using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BT
{
    internal class Program
    {
        static Product findProduct(List<Product> listProduct, string nameProduct)
        {
            foreach (Product product in listProduct)
            {
                if (product.Name == nameProduct)
                {
                    return product;
                }
            }
            return null;
        }
        static List<Product> findProductByCategory(List<Product> listProducts, int categoryId)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in listProducts)
            {
                if (product.CategoryId == categoryId)
                {
                    result.Add(product);
                }
            }
            return result;
        }
        static List<Product> findProductByPrice(List<Product> listProduct, int price)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in listProduct)
            {
                if (product.Price <= price)
                {
                    result.Add(product);
                }
            }
            return result;
        }
        static List<Product> sortByPrice(List<Product> listProduct)
        {
            for (int i = 0; i < listProduct.Count - 1; i++)
            {
                //lặp theo cặp
                for (int j = 0; j < listProduct.Count - i - 1; j++)
                {
                    if (listProduct[j].Price > listProduct[j + 1].Price)
                    {
                        Product temp = listProduct[j];
                        listProduct[j] = listProduct[j + 1];
                        listProduct[j + 1] = temp;
                    }
                }
            }
            return listProduct;
        }
        static List<Product> sortByName(List<Product> listProduct)
        {
            for (int i = 1; i < listProduct.Count; i++)
            {
                Product keyProduct = listProduct[i];
                int j = i - 1;

                while (j >= 0 && listProduct[j].Name.Length < keyProduct.Name.Length)
                {
                    listProduct[j + 1] = listProduct[j];
                    j--;
                }
                listProduct[j + 1] = keyProduct;
            }
            return listProduct;
        }
        static void sortByCategoryName(List<Product> listProduct, List<Category> listCategorys)
        {
            var sx = listCategorys[0].name.ToCharArray()[0] < listCategorys[1].name.ToCharArray()[0];
            for (int i = 1; i < listCategorys.Count; i++)
            {
                
            }
     
        }
        static Product minByPrice(List<Product> listProduct)
        {
            Product minProduct = listProduct[0];
            foreach (Product p in listProduct)
            {
                if (p.Price < minProduct.Price)
                {
                    minProduct = p;
                }
            }
            return minProduct;
        }

        static Product maxByPrice(List<Product> listProduct)
        {
            Product maxProduct = listProduct[0];
            foreach (Product p in listProduct)
            {
                if (p.Price > maxProduct.Price)
                {
                    maxProduct = p;
                }
            }
            return maxProduct;
        }
        static void Main(string[] args)
        {
            int luachon, b;
            string a;
            List<Product> products = new List<Product>()
            {
                new Product { Name = "CPU", Price = 750, Quality = 10, CategoryId = 1 },
                new Product { Name = "RAM", Price = 50, Quality = 2, CategoryId = 2 },
                new Product { Name = "HDD", Price = 70, Quality = 1, CategoryId = 2 },
                new Product { Name = "Main", Price = 400, Quality = 3, CategoryId = 1 },
                new Product { Name = "Keyboard", Price = 30, Quality = 8, CategoryId = 4 },
                new Product { Name = "Mouse", Price = 25, Quality = 50, CategoryId = 4 },
                new Product { Name = "VGA", Price = 60, Quality = 35, CategoryId = 3 },
                new Product { Name = "Monitor", Price = 120, Quality = 28, CategoryId = 2 },
                new Product { Name = "Case", Price = 120, Quality = 28, CategoryId = 5 }
            };
            List<Category> category = new List<Category>()
            {
                new Category {id = 1, name ="Computer"},
                new Category {id = 2, name ="Memory"},
                new Category {id = 3, name ="Card"},
                new Category {id = 4, name ="Acsesory"}
            };
            Console.WriteLine("4.findProduct");
            Console.WriteLine("5.findProductbyCategory");
            Console.WriteLine("6.findProductbyPrice");
            Console.WriteLine("11.sortByPrice");
            Console.WriteLine("12.sortByName");
            Console.WriteLine("13.sortByCategoryName");
            Console.WriteLine("14.mapProductByCategory");
            Console.WriteLine("15.minByPrice");
            Console.WriteLine("16.maxByPrice");
            Console.WriteLine("----------------------- ");
            Console.Write("Chon so bai: ");
            luachon = int.Parse(Console.ReadLine());
            switch (luachon)
            {
                case 4:
                    Product result = findProduct(products, "CPU");
                    Console.WriteLine($"Ten: {result.Name}");
                    Console.WriteLine($"Gia: {result.Price}");
                    Console.WriteLine($"Chat luong: {result.Quality}");
                    Console.WriteLine($"CategoryId: {result.CategoryId}");
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                break;
                case 5:
                    int categoryId = 2;
                    List<Product> result2 = findProductByCategory(products, categoryId);
                    foreach (Product product in result2)
                    {
                        Console.WriteLine($"Ten: {product.Name}");
                        Console.WriteLine($"Gia: {product.Price}");
                        Console.WriteLine($"Chat luong: {product.Quality}");
                        Console.WriteLine($"CategoryId: {product.CategoryId}");
                        Console.WriteLine("--------------------------");
                        
                    }
                    Console.ReadLine();
                    break;
                case 6:
                    int sprice = 50;
                    List<Product> result3 = findProductByPrice(products, sprice);
                    foreach (Product product in result3)
                    {
                        Console.WriteLine($"Ten: {product.Name}");
                        Console.WriteLine($"Gia: {product.Price}");
                        Console.WriteLine($"Chat luong: {product.Quality}");
                        Console.WriteLine($"CategoryId: {product.CategoryId}");
                        Console.WriteLine("--------------------------"); 
                    }
                    Console.ReadLine();
                    break;
                case 11:
                    List<Product> result4 = sortByPrice(products);
                    foreach (Product product in result4)
                    {
                        Console.WriteLine($"Ten: {product.Name} | Gia: {product.Price} | Chat luong: {product.Quality} CategoryId: {product.CategoryId} " );
                        
                    }
                    Console.ReadLine();
                    break;
                case 12:
                    List<Product> result5 = sortByName(products);
                    foreach (Product product in result5)
                    {
                        Console.WriteLine($"Ten: {product.Name} | Gia: {product.Price} | Chat luong: {product.Quality} CategoryId: {product.CategoryId} ");
                       
                    }
                    Console.ReadLine();
                    break;
                case 13:
                    Console.WriteLine("Chua hoan thanh!");
                    Console.ReadLine();
                    break;
                case 14:
                    sortByCategoryName(products, category);
                    Console.ReadLine();
                    break;
                case 15:
                    Product result6 = minByPrice(products);
                    Console.WriteLine("San pham co gia nho nhat");
                    Console.WriteLine($"Ten: {result6.Name}");
                    Console.WriteLine($"Gia: {result6.Price}");
                    Console.WriteLine($"Chat luong: {result6.Quality}");
                    Console.WriteLine($"CategoryId: {result6.CategoryId}");
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;
                 case 16:
                    Product result7 = maxByPrice(products);
                    Console.WriteLine("San pham co gia lon nhat");
                    Console.WriteLine($"Ten: {result7.Name}");
                    Console.WriteLine($"Gia: {result7.Price}");
                    Console.WriteLine($"Chat luong: {result7.Quality}");
                    Console.WriteLine($"CategoryId: {result7.CategoryId}");
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;

            }
            



        }
    }
}

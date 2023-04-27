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
        public static List<Product> sortByCategoryName(List<Product>  listProducts, List<Category> listcategory)
        {
            List<string> sortedCategoryNames = listcategory.OrderBy(c => c.name).Select(c => c.name).ToList();
            List<Product> sortedProducts = new List<Product>();

            foreach (string categoryName in sortedCategoryNames)
            {
                foreach (Product product in listProducts)
                {
                    if (product.CategoryId != null)
                    {
                        Category productCategory = listcategory.FirstOrDefault(c => c.id == product.CategoryId);

                        if (productCategory != null && productCategory.name == categoryName)
                        {
                            sortedProducts.Add(product);
                        }
                    }
                }
            }
            return sortedProducts;
        }
        public static List<Product> MapProductByCategory(List<Product> listProduct, List<Category> listCategory)
        {
            Dictionary<int, string> categoryNames = new Dictionary<int, string>();
            foreach (Category category in listCategory)
            {
                int categoryId = category.id;
                string categoryName = category.name;
                categoryNames[categoryId] = categoryName;
            }
            List<Product> mappedProducts = new List<Product>();
            foreach (Product product in listProduct)
            {
                int categoryId = product.CategoryId;
                if (categoryNames.ContainsKey(categoryId))
                {
                    string categoryName = categoryNames[categoryId];
                    Product mappedProduct = new Product
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quality = product.Quality,
                        CategoryId = product.CategoryId,
                        CategoryName = categoryName 
                    };
                    mappedProducts.Add(mappedProduct);
                }
            }
            return mappedProducts;
        }


        static Product minByPrice(List<Product> listProduct)
        {
            Product minProduct = listProduct[0];
            foreach (Product product in listProduct)
            {
                if (product.Price < minProduct.Price)
                {
                    minProduct = product;
                }
            }
            return minProduct;
        }

        static Product maxByPrice(List<Product> listProduct)
        {
            Product maxProduct = listProduct[0];
            foreach (Product product in listProduct)
            {
                if (product.Price > maxProduct.Price)
                {
                    maxProduct = product;
                }
            }
            return maxProduct;
        }
        static double recursionCalSalary(double salary, int n)
        {
            if (n == 1)
            {
                return salary;
            }
            else
            {
                return recursionCalSalary(salary * 1.1, n - 1);
            }
            
        }
        static double notRecursionCalSalary(double salary, int n)
        {
            double result = salary;
            for (int i = 1; i < n; i++)
            {
                result *= 1.1;
            }
            return result;
        }
        static int recursionCalMonth(double money, double rate, int month, double target)
        {
            if (money >= target) 
            {
                return month;
            }
            else
            {
                month++;
                double interest = money * rate / 100;
                money += interest;
                return recursionCalMonth(money, rate, month, target);
                
            }
        }
        static int notRecursionCalMonth(double money, double rate)
        {
            //int month = (int)(money / money * rate);
            int month = 0;
            double target = 2 * money;

            while (money < target)
            {
                month++;
                double interest = money * rate / 100;
                money += interest;
            }
            return month;
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
                new Product { Name = "Case", Price = 120, Quality = 28, CategoryId = 1 }
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
            Console.WriteLine("21.calSalary");
            Console.WriteLine("22.calMonth");
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
                    List<Product> result9 = sortByCategoryName(products, category);
                    foreach (Product product in result9)
                    {
                        Console.WriteLine($"Ten: {product.Name} | Gia: {product.Price} | Chat luong: {product.Quality} CategoryId: {product.CategoryId} ");


                    }
                    Console.ReadLine();
                    break;
                case 14:
                    List<Product> mappedProducts = MapProductByCategory(products, category);

                    foreach (Product product in mappedProducts)
                    {
                        Console.WriteLine($"Ten: {product.Name} | Gia: {product.Price}, Chat luong: {product.Quality}, Category: {product.CategoryName}");
                    }
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
                 case 21:
                    double salary = 10000000;
                    int n = 5;
                    double result8 = recursionCalSalary(salary, n);
                    double result10 = notRecursionCalSalary(salary, n);
                    Console.WriteLine($"De qui: Luong {salary} sau {n} thang {result8}");
                    Console.WriteLine($"Khong de qui: Luong {salary} sau {n} thang {result10}");
                    Console.ReadKey();
                    break;
                 case 22:
                    double money = 20000, rate = 10, target = 2*money;
                    double result11 = recursionCalMonth(money, rate, 0, target);
                    double result12 = notRecursionCalMonth(money, rate);
                    Console.WriteLine($"De qui: So tien {money} lai suat {rate}% tang gap doi can {result11} thang");
                    Console.WriteLine($"Khong de qui: So tien {money} lai suat {rate}% tang gap doi can {result12} thang");
                    Console.ReadKey();
                    break;

            }
            



        }
    }
}

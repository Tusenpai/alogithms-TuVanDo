﻿using System;
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
            List<Product> result2 = new List<Product>();
            foreach (Product p in listProducts)
            {
                if (p.CategoryId == categoryId)
                {
                    result2.Add(p);
                }
            }
            return result2;
        }
        static List<Product> findProductByPrice(List<Product> listProduct, int price)
        {
            List<Product> result3 = new List<Product>();
            foreach (Product a in listProduct)
            {
                if (a.Price <= price)
                {
                    result3.Add(a);
                }
            }
            return result3;
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
            Console.WriteLine("4.findProduct");
            Console.WriteLine("5.findProductbyCategory");
            Console.WriteLine("6.findProductbyPrice");
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
                    foreach (Product p in result2)
                    {
                        Console.WriteLine($"Ten: {p.Name}");
                        Console.WriteLine($"Gia: {p.Price}");
                        Console.WriteLine($"Chat luong: {p.Quality}");
                        Console.WriteLine($"CategoryId: {p.CategoryId}");
                        Console.WriteLine("--------------------------");
                        Console.ReadLine();
                    }
                break;
                case 6:
                    int sprice = 50;
                    List<Product> result3 = findProductByPrice(products, sprice);
                    foreach (Product p in result3)
                    {
                        Console.WriteLine($"Ten: {p.Name}");
                        Console.WriteLine($"Gia: {p.Price}");
                        Console.WriteLine($"Chat luong: {p.Quality}");
                        Console.WriteLine($"CategoryId: {p.CategoryId}");
                        Console.WriteLine("--------------------------");
                        Console.ReadLine();
                    }
                    break;
                
            }


        }
    }
}

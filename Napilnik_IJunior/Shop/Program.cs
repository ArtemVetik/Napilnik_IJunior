using System;
using System.Collections.Generic;

namespace Napilnik.Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком
            Console.WriteLine("Items in warehouse:");
            foreach (var cell in warehouse.Goods)
                Console.WriteLine($"name: {cell.Key.Name}\tcount: {cell.Value}");
            Console.WriteLine(new string('-',30));

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            //cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            Console.WriteLine("Items in cart:");
            foreach (var item in cart.Items)
                Console.WriteLine($"name: {item.Key.Name}\tcount: {item.Value}");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(cart.Order().Paylink);
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Items in warehouse after order:");
            foreach (var cell in warehouse.Goods)
                Console.WriteLine($"name: {cell.Key.Name}\tcount: {cell.Value}");
            Console.WriteLine(new string('-', 30));

            //cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}

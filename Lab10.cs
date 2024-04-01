using System;

// Класс для представления товара
class Product
{
    public string ProductCode { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Метод для расчета общей стоимости товара
    public double CalculateTotalPrice()
    {
        return Price * Quantity;
    }
}

// Класс для представления поставщика
class Supplier
{
    public string Name { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ласкаво просимо!");

        // Ввод данных о поставщике
        Console.WriteLine("Введіть назву фірми постачальника:");
        string supplierName = Console.ReadLine();

        // Ввод данных о товаре
        Console.WriteLine("Введіть артикул товару:");
        string productCode = Console.ReadLine();

        double price;
        while (true)
        {
            Console.WriteLine("Введіть ціну товару:");
            if (double.TryParse(Console.ReadLine(), out price) && price > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректну ціну.");
            }
        }

        int quantity;
        while (true)
        {
            Console.WriteLine("Введіть кількість товару:");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректну кількість.");
            }
        }

        // Создание экземпляров классов
        Supplier supplier = new Supplier { Name = supplierName };
        Product product = new Product { ProductCode = productCode, Price = price, Quantity = quantity };

        // Рассчитываем сумму заказа
        double totalOrderPrice = product.CalculateTotalPrice();

        // Вывод данных на проверку
        Console.WriteLine("Перевірте дані:");
        Console.WriteLine($"Постачальник: {supplier.Name}");
        Console.WriteLine($"Артикул товару: {product.ProductCode}");
        Console.WriteLine($"Ціна: {product.Price}");
        Console.WriteLine($"Кількість: {product.Quantity}");
        Console.WriteLine($"Сума замовлення: {totalOrderPrice}");

        // Ввод даты покупки
        Console.WriteLine("Введіть дату (рррр-мм-дд):");
        string purchaseDateInput = Console.ReadLine();

        DateTime purchaseDate;
        if (DateTime.TryParse(purchaseDateInput, out purchaseDate))
        {
            // Данные верны, покупка завершена
            Console.WriteLine("Покупка завершена.");
        }
        else
        {
            // Некорректный формат даты
            Console.WriteLine("Некорректний формат дати. Покупка відмінена.");
        }
    }
}

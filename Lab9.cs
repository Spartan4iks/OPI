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
        Console.WriteLine("Введіть назву фірми постачальника:");
        string supplierName = Console.ReadLine();

        Console.WriteLine("Введіть артикул товару:");
        string productCode = Console.ReadLine();

        Console.WriteLine("Введіть ціну товару:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть кількість товару:");
        int quantity = Convert.ToInt32(Console.ReadLine());

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

        Console.WriteLine("Якщо дані вірні, введіть дату (рррр-мм-дд):");
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
            Console.WriteLine("Некорректний формат даты. Покупка відмінена.");
        }
    }
}

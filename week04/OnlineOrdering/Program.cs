using System;

class Program
{
    static void Main(string[] args)
    {
        // Customer 1 (USA)
        Address addr1 = new Address("Flat 235B Fredshed Street, Port Harcourt", "River State", "RS", "NIGERIA");
        Customer cust1 = new Customer("Idris Danjuma", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "LAP123", 1000, 1));
        order1.AddProduct(new Product("Mouse", "MOU456", 25, 2));

        // Customer 2 (International)
        Address addr2 = new Address("No. 45 Jude's Avenue, Aba", "Abia State", "AS", "NIGERIA");
        Customer cust2 = new Customer("Alice Smith", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Smartphone", "PHN789", 800, 1));
        order2.AddProduct(new Product("Headphones", "HDP101", 150, 1));
        order2.AddProduct(new Product("Charger", "CHR202", 20, 3));

        // Display Order 1
        Console.WriteLine("ORDER 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // Display Order 2
        Console.WriteLine("ORDER 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}

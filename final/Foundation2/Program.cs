using System;

class Program
{
    static void Main(string[] args)
    {
//Create orders
        Order order1 = new Order(
        new Customer("John Doe", new Address("1472 Ave", "Provo", "UT", "US")),
        new[] {
            new Product("Playstation 4", "PS4", 300.99f, 2),
            new Product("Dell Computer", "DC", 700.99f, 3),
        });
        Order order2 = new Order(
        new Customer("Jane Doe", new Address("1572 Service Rd", "Orem", "UT", "US")),
        new[] {
            new Product("Basket", "BSK", 30.99f, 1),
            new Product("Monopoly", "MPY", 24.99f, 2),
            new Product("Blinds", "BLD", 49.99f, 5),
        });
        Order order2 = new Order(
        new Customer("Christopher Columbus", new Address("1492 Ocean Blue St", "Valladolid", "Madrid", "ES")),
        new[] {
            new Product("Shoes", "SH", 30.99f, 4),
            new Product("Laces", "LC", 5.99f, 2),
            new Product("Shoe Cleaner", "SHC", 17.99f, 13),
        });    

// Display info
        Console.WriteLine("\nOrder 1");
        Console.WriteLine("-----------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        string v = $"Total Price: ${order1.GetTotalPrice()}";
        Console.WriteLine(v);

        Console.WriteLine("\nOrder 2");
        Console.WriteLine("-----------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        string z = $"Total Price: ${order2.GetTotalPrice()}";
        Console.WriteLine(z);

        Console.WriteLine("\nOrder 3");
        Console.WriteLine("-----------");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        string x = $"Total Price: ${order3.GetTotalPrice()}";
        Console.WriteLine(x);
    }
}

 //Order class
 class Order{

    private Product[] _products;
    private Customer _customer;

    public Order(Customer customer, Product[] products){
         _customer = customer;
         _products = products;
    }

    public float GetTotalPrice(){
        float subtotal = 0;
        foreach (var product in _products)
        {
            subtotal += product.GetPrice() * product.GetQuantity();
        }
        float shippingCost = _customer.GetAddress().IsInUSA() ? 5f : 35f;
        return subtotal + shippingCost;
    }
    public string GetPackingLabel()
    {
    var label = ($"Packing Label:\n");        
    foreach (var product in _products)
    {
        label += ($"{product.GetName()} ({product.GetID()})\n");
    }
    return label;
    }
    public string GetShippingLabel()
    {
    return ($"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().ToString()}");
    }
 }

 //Products class
 class Product
{
    private string _name;
    private string _id;
    private float _price;
    private int _quantity;

    public Product(string name, string id, float price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetID()
    {
        return _id;
    }
    public float GetPrice()
    {
        return _price;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
}

//Customer class




//Address class

namespace FoodDelivery.Core;

public class Dish
{
    public string Name { get; }
    public decimal Price { get; }

    public Dish(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва страви не може бути порожньою.", nameof(name));
        
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Ціна страви не може бути від'ємною.");

        Name = name;
        Price = price;
    }
}
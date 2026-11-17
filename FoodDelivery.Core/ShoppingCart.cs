namespace FoodDelivery.Core;

public class ShoppingCart
{
    private readonly List<Dish> _items = new();

    public IReadOnlyList<Dish> Items => _items.AsReadOnly();

    public void AddDish(Dish dish)
    {
        if (dish == null)
            throw new ArgumentNullException(nameof(dish), "Страва не може бути null.");

        _items.Add(dish);
    }

    public decimal CalculateTotal(decimal discountPercent = 0)
    {
        if (discountPercent < 0 || discountPercent > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercent), "Знижка має бути в межах від 0 до 100%.");

        decimal sum = _items.Sum(d => d.Price);
        decimal discountAmount = sum * (discountPercent / 100m);
        return sum + discountAmount;
    }
}
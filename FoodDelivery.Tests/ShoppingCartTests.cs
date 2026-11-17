using FoodDelivery.Core;
using Xunit;

namespace FoodDelivery.Tests;

public class ShoppingCartTests
{
    [Fact]
    public void AddDish_ValidDish_AddsToCartAndIncreasesCount()
    {
        var cart = new ShoppingCart();
        var pizza = new Dish("Маргарита", 250m);

        cart.AddDish(pizza);

        Assert.Single(cart.Items);
        Assert.Equal("Маргарита", cart.Items[0].Name);
    }

    [Fact]
    public void CalculateTotal_MultipleDishes_ReturnsCorrectSum()
    {
        var cart = new ShoppingCart();
        cart.AddDish(new Dish("Бургер", 180m));
        cart.AddDish(new Dish("Картопля фрі", 70m));

        var total = cart.CalculateTotal();

        Assert.Equal(250m, total);
    }

    [Fact]
    public void CalculateTotal_EmptyCart_ReturnsZero()
    {
        var cart = new ShoppingCart();

        var total = cart.CalculateTotal();

        Assert.Equal(0m, total);
    }

    [Fact]
    public void CalculateTotal_WithValidDiscount_AppliesDiscountCorrectly()
    {
        var cart = new ShoppingCart();
        cart.AddDish(new Dish("Суші сет", 500m));

        var total = cart.CalculateTotal(discountPercent: 20m);

        Assert.Equal(400m, total);
    }

    [Fact]
    public void Dish_NegativePrice_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Dish("Борщ", -50m));
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(105)]
    public void CalculateTotal_InvalidDiscount_ThrowsArgumentOutOfRangeException(decimal invalidDiscount)
    {
        var cart = new ShoppingCart();
        cart.AddDish(new Dish("Салат Цезар", 150m));

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.CalculateTotal(invalidDiscount));
    }
}
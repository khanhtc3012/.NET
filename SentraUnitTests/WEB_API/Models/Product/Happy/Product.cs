using NUnit.Framework;
using WEB_API.Models;

[TestFixture]
public class ProductTests
{
    [Test]
    public void TestProductConstructor()
    {
        // Arrange
        var product = new Product();

        // Assert
        Assert.IsNotNull(product);
        Assert.IsNotEmpty(product.Sku);
        Assert.IsEmpty(product.Content);
        Assert.AreEqual(0, product.Price);
        Assert.IsNull(product.DiscountPrice);
        Assert.IsFalse(product.IsActive);
        Assert.IsEmpty(product.ImageUrl);
        Assert.AreEqual(0, product.ViewCount);
        Assert.IsNotEmpty(product.CreatedAt.ToString());
    }

    [Test]
    public void TestProductProperties()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Sku = "SKU123",
            Content = "This is a product description.",
            Price = 19.99f,
            DiscountPrice = 14.99f,
            IsActive = true,
            ImageUrl = "https://example.com/product.jpg",
            ViewCount = 50,
            CreatedAt = DateTime.Now
        };

        // Assert
        Assert.AreEqual(1, product.Id);
        Assert.AreEqual("SKU123", product.Sku);
        Assert.AreEqual("This is a product description.", product.Content);
        Assert.AreEqual(19.99f, product.Price);
        Assert.AreEqual(14.99f, product.DiscountPrice);
        Assert.IsTrue(product.IsActive);
        Assert.AreEqual("https://example.com/product.jpg", product.ImageUrl);
        Assert.AreEqual(50, product.ViewCount);
        Assert.IsNotEmpty(product.CreatedAt.ToString());
    }
}
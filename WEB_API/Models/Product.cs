namespace WEB_API.Models
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Content { get; set; }
        public float Price { get; set; }
        public float? DiscountPrice { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

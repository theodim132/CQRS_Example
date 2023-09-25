namespace CQRS_Example.Domain.Entities.Products
{
    public class Product
    {
        public int Id { get;  set; }
        public string Name { get;  set; } = string.Empty;

        //public Money Price { get;  set; }

        //public Sku Sku { get;  set; }
    }
}

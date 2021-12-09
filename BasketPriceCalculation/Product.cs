using System;

namespace BasketPriceCalculation
{
    public abstract class Product
    {
        public Product(int id, string description, decimal unitPrice)
        {
            Id = id;
            Description = description;
            UnitPrice = unitPrice;
        }

        public int Id { get; }
        public string Description { get; }
        public decimal UnitPrice { get; }
    }

    /// <summary>
    /// I'm adding the specific product classes (with hard coding) for facilitating unit tests
    /// in this solution. In real world the number of products will be many
    /// and they will be stored in a master table in the database. In that scenario there will not be these
    /// specific product classes and generic class (say Product) will store the properties of specific products
    /// </summary>
    public class Butter : Product
    {
        public Butter() : base(1, "Butter", 0.80M)
        {

        }
    }

    public class Milk : Product
    {
        public Milk() : base(2, "Milk", 1.15M)
        {

        }
    }

    public class Bread : Product
    {
        public Bread() : base(3, "Bread", 1.0M)
        {

        }
    }
}

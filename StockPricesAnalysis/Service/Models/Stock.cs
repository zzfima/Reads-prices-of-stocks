namespace Service.Models
{
    /// <summary>
    /// Stock entity
    /// </summary>
    public class Stock
    {
        public int Price { get; }
        public string Name { get; }

        public Stock(string name, int price)
        {
            Price = price;
            Name = name;
        }
    }
}

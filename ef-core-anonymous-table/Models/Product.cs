namespace ef_core_anonymous_table.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}

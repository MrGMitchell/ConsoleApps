namespace Question3.Models
{
    public class Item
    {
        public UInt64 product { get; set; }
        public string desc { get; set; }
        public int qty { get; set; }
        public decimal basePrice { get; set; }
        public decimal itemPrice { get; set; }
        public List<Adjustment> adjustments { get; set; }
    }
}
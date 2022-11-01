namespace Question3.Models
{
    public class Order
    {
        public decimal totalOrderValue {get; set;}
        public decimal totalDiscount { get; set; }
        public decimal totalOrderValuePostDiscount { get; set; }
        public decimal totalCouponDiscount { get; set; }
        public decimal totalTax { get; set; }
        public decimal movFee { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal netInvoice { get; set; }
        public string outletId { get; set; }
        public DateTime orderDate { get; set; }
        public List<Item> item { get; set; }

        public Order() {
            orderDate = DateTime.Now;
        }
    }
}

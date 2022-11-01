using Newtonsoft.Json;
using Question3.Models;
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

using (var stream = assembly.GetManifestResourceStream("Question3.Files.order.json"))

using (StreamReader file = new StreamReader(stream))
{
    string json = file.ReadToEnd();
    Order order = JsonConvert.DeserializeObject<Order>(json);

    /*
        If writing an API that multiple callers will use, then you first need to create a standard format. 
        I know the instructions say that the API must support the format given but that format is not valid JSON and the API should not process this.
        If one were to decide to write the API for this format you will eventually end up with many different formats for many different customers.
        Making your API harder to support. So I would first request that the caller fix their JSON format. 
        For C# Web APIs, I have used things like FluentValidator to validate input to the API.
    
        The test file included has already been updated.

        Also, to support multiple calls to the API you would want to make sure you endpoint is async. That way the caller is not waiting on the API to 
        process the business logic as that can take awhile depending on how complex the checks are.

        You can use a processing queue to help with performance.
     */

    /*===================================================================================================================================
    Check to see if outletId already received.
        If already received then send a notification to the caller letting them know that outlet Id has already been received.

    If Not then iterate through product list checking the last order date for that product and the quantity ordered.
      If a product is ordered twice in the same day for the same quanity then ignore the order.
      You would want to send a notification back to the caller letting them know the order was ignored.

    If order passes all validation checks insert order and send a message to the caller letting them know the order was recieved and entered.
    ==================================================================================================================================*/
    Console.WriteLine($"Order Summary [{order.outletId}]");
    Console.WriteLine($"====================");
    Console.WriteLine($"SubTotal: {order.totalOrderValue}");
    Console.WriteLine($"Total Discount: {order.totalDiscount}");
    Console.WriteLine($"Tax: {order.totalTax}");
    Console.WriteLine($"Mov Fee: {order.movFee}");
    Console.WriteLine($"Delivery Fee: {order.deliveryFee}");
    Console.WriteLine($"Total: {order.netInvoice}");
    Console.WriteLine($"====================");
    Console.WriteLine($"======Products======");
    foreach (var p in order.item) {
        Console.WriteLine($"====================");
        Console.WriteLine($"Product #: {p.product}");
        Console.WriteLine($"Description: {p.desc}");
        Console.WriteLine($"Qty: {p.qty}");
        Console.WriteLine($"Price: {p.basePrice}");
        if (p.adjustments.Count()>0) {
            Console.WriteLine($"**Adjustments**");
            foreach (var a in p.adjustments)
            {
                if (a.amount==0) {
                    continue;
                }
                Console.WriteLine($"Adjustment: {a.adjustment}");
                Console.WriteLine($"Amt: {a.amount}");
                Console.WriteLine($"Adjustment Desc: {a.desc}");
            }
            Console.WriteLine($"");
        }
        Console.WriteLine($"Total Price: {p.itemPrice}");
        Console.WriteLine($"");
    }
    Console.ReadKey();
}
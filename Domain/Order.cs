namespace Domain;

public class Order
{
    public long Id { get; set; }

    public List<string> OrderItems { get; set; }
    
    public decimal TotalAmount { get; set; }
}
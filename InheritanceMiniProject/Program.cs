



List<IRentable> rentables = new List<IRentable> ();
List<IPurchasable> purchasables = new List<IPurchasable> ();

var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia Optima" };

var book = new BookModel { ProductName = "A Tale of Two Cities", NumberOfPages = 350 };

var excavator = new Excavator {  ProductName = "Bulldozer", QuantityInStock = 2 };

rentables.Add (vehicle);
rentables.Add(excavator);

purchasables.Add(vehicle);
purchasables.Add(book);

Console.Write("Do you want to rent or purchase something: (rent), (purchase) ");
string rentalDecision = Console.ReadLine ();

if (rentalDecision.ToLower() == "rent")
{
    foreach (var rentable in rentables)
    {
        Console.WriteLine($"Item: {rentable.ProductName}, ");
        Console.Write("Do you want to rent this item (yes/no)");
        string wantToRent = Console.ReadLine ();    
        if (wantToRent.ToLower() == "yes")
        {
            rentable.Rent();
        }

        Console.Write("Do you want to return this item (yes/no)");
        string wantToReturn = Console.ReadLine();
        if (wantToReturn.ToLower() == "yes")
        {
            rentable.ReturnRental();
        }
    }
}
else
{
    foreach (var purchasable in purchasables)
    {
        Console.WriteLine($"Item: { purchasable.ProductName}");
        Console.Write("Do you want to purchase the item: (yes/no) ");
        string wantToBuy = Console.ReadLine ();

        if (wantToBuy.ToLower() == "yes")
        {
            purchasable.Purchase();
        }
    }
}


Console.ReadLine();


public interface IInventoryItem
{
    string ProductName { get; set; }

    int QuantityInStock { get; set; }
}

public interface IRentable : IInventoryItem
{
    void Rent();
    void ReturnRental();
}

public interface IPurchasable : IInventoryItem
{
    void Purchase();

}


public class InventoryItemModel : IInventoryItem
{
    public string ProductName { get; set; }

    public int QuantityInStock { get; set; }

}

public class VehicleModel :InventoryItemModel, IRentable,IPurchasable
{
    public decimal DealerFee { get; set; }

    public void Purchase()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This vehical has been purchased.");
    }

    public void Rent()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This vehical has been rented.");
    }

    public void ReturnRental()
    {
        QuantityInStock += 1;
        Console.WriteLine("This vehical has been returned.");
    }
}

public class BookModel :InventoryItemModel, IPurchasable
{
    public int NumberOfPages { get; set; }

    public void Purchase()
    {
        throw new NotImplementedException();
    }
}

public class Excavator: InventoryItemModel, IRentable
{
    public void Dig()
    {
        Console.WriteLine("I am digging.");
    }

    public void Rent()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This excavator has been rented.");
    }

    public void ReturnRental()
    {
        QuantityInStock += 1;
        Console.WriteLine("This excavator has been returned.");
    }
}
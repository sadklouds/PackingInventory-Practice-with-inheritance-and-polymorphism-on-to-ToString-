

// Add items to an pack (inventory) after one is created until the item limit, weight limit or volume limit is reached 

Pack pack = new(10,20,10);
while (true)
{
    Console.WriteLine($"{pack} ");
    Console.WriteLine($"items: {pack.Count}/{pack.MaximumItems}, weight: {pack.CurrentWeight}/{pack.MaximumWeight}, Volume:{pack.CurrentVolume}/{pack.MaximumVolume} ");
    Console.WriteLine("\nSelect items below to add to pack");
    Console.WriteLine("1: Arrow");
    Console.WriteLine("2: Bow");
    Console.WriteLine("3: Rope");
    Console.WriteLine("4: Water");
    Console.WriteLine("5: Food Rations");
    Console.WriteLine("6: Sword");
    Console.Write("Enter number: ");
    string input = Console.ReadLine();
    bool check;
    switch (input)
    {
        case "1":
            Arrow arrow = new();
            check = pack.Add(arrow);
            Console.WriteLine($"\n{check}");
            Console.WriteLine($"\n{arrow.ToString()}");
            break;
        case "2":
            Bow bow = new();
            check = pack.Add(bow);
            Console.WriteLine($"\n{check}");
            break;
        case "3":
            Rope rope = new();
            check = pack.Add(rope);
            Console.WriteLine($"\n{check}");
            break;
        case "4":
            Water water= new();
            check = pack.Add(water);
            Console.WriteLine($"\n{check}");
            break;
        case "5":
            FoodRations food = new();
            check = pack.Add(food);
            Console.WriteLine($"\n{check}");
            break;
        case "6":
            Sword sword = new();
            check = pack.Add(sword);
            Console.WriteLine($"\n{check}");
            break;
        default:
            Console.WriteLine("Unknown item");
            break;
    }
    Console.WriteLine($"weight : {pack.CurrentWeight}");
}

public class Pack
{
    public  float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }
    public  float MaximumWeight { get;  }
    public float MaximumVolume { get;  }
    public float MaximumItems { get; }
    public int Count { get; private set; } = 0;

    InventoryItem[] Items;
    public Pack (float maxWeight, float maxVolume, int maxItems)
    {
        MaximumWeight = maxWeight;
        MaximumVolume = maxVolume;
        MaximumItems = maxItems;
        Items = new InventoryItem[maxItems];
    }

    public override string ToString()
    {
        string valuables = "Pack:";
       for (int itemCount = 0; itemCount < Count; itemCount ++)
        {
            valuables += Items[itemCount].ToString() +", ";
        }
        return valuables;
    }
        

    public bool Add(InventoryItem item)
    {
        if (Count >= MaximumItems) return false;
        if (CurrentVolume + item.Volume > MaximumVolume || CurrentWeight + item.Weight > MaximumWeight) return false;

        Items[Count] = item;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
      
        Count++;
        return true;
        
    }
}
 // base item class for all item subclass/subtypes 
public class InventoryItem
{
    public float Weight { get;  }
    public float Volume { get; }
    
    public InventoryItem (float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }

}
// inherited class for creating items 
// each class overrrides string method from object bas class 
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString() { return base.ToString(); }
}
public class Bow : InventoryItem 
{ 
    public Bow() : base(1f, 4f) { }
    public override string ToString() { return base.ToString(); }
}
public class Rope : InventoryItem
{ 
    public Rope() : base(1f, 1.5f) { }
    public override string ToString() { return base.ToString(); }
}
public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
    public override string ToString() { return base.ToString(); }
}
public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, 0.5f) { }
    public override string ToString() { return base.ToString(); }
}
public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
    public override string ToString() { return base.ToString(); }
}
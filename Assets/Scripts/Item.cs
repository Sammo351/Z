public class Item
{
    string name = "My Item";
    int maxStackSize = 32;
    
    public Item(string _name)
    {
        name = _name;
    }

    public int MaxStackSize
    {
        get { return maxStackSize; }
        set { maxStackSize = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public static bool operator ==(Item item, Item item2)
    {
        return item.Name == item2.Name;
    }

      public static bool operator !=(Item item, Item item2)
    {
        return item.Name != item2.Name;
    }

}
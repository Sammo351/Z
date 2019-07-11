public class ItemStack
{
    Item item;
    int quantity;

    public ItemStack(Item _item, int _q)
    {
        item = _item;
        quantity = _q;
    }
    public Item GetItem()
    {
        return item;
    }
    public bool IsValid()
    {
        return item != null && quantity>0;
    }
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}
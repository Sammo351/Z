using System.Collections.Generic;

public class Inventory
{
    public EntityBase owner;
    List<ItemStack> items;
    int maxSlots = 18;
    Inventory(EntityBase _owner, int _maxSlots = 18)
    {
        owner = _owner;
        items = new List<ItemStack>();
        maxSlots = _maxSlots;
    }
    public void InsertItemStack(ItemStack stack)
    {

    }
    void AppendStack(ItemStack stack)
    {
        if(stack.IsValid())
        {
            for (int i = 0; i < items.Count; i++)
            {
                ItemStack check = items[i];
                if(check != null && check.IsValid())
                {
                    if(check.GetItem() == stack.GetItem())
                    {
                        
                    }
                }
               
            }
        }
    }
}


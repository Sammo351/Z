using System.Collections.Generic;

public class Inventory
{
    public EntityBase owner;
    List<ItemStack> items;
    int maxSlots = 18;

    public Inventory(EntityBase _owner, int _maxSlots = 18)
    {
        owner = _owner;
        items = new List<ItemStack>();
        maxSlots = _maxSlots;
    }
    
    //Add stack to a certain slot, return the leftover
    public void InsertItemStack(ItemStack stack, int slot)
    {
        AppendStack(stack);
        
    }

    //Automatically add stack to the inventory
    void AppendStack(ItemStack stack)
    {
        if (stack.IsValid())
        {
            int remaining = stack.Quantity;
            for (int i = 0; i < items.Count; i++)
            {
                if (remaining <= 0)
                {
                    break;
                }
                ItemStack check = items[i];
                if (check != null && check.IsValid())
                {
                    if (check.GetItem() == stack.GetItem())
                    {
                        //add to inventory slot
                        //take from stack
                    }
                }

            }
            if (remaining > 0)
            {
                //Place in a new slot
            }

        }
    }

}


using Godot;
using Godot.Collections;
using System;

public partial class ItemManager : Node
{
    private Dictionary<Material, int> _items = [];
    
    public void AddItem(string itemName, int amount = 1)
    {
    }
}

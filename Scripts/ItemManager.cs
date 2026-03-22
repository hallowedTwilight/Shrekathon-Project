using Godot;
using Godot.Collections;
using System;

public partial class ItemManager : Node
{
    private Dictionary<Material, int> _items = [];
    
    public void AddItem(Material itemName, int amount = 1)
    {
        if (_items.ContainsKey(itemName))
            _items[itemName] += amount;
        else
            _items[itemName] = amount;
    }
    public bool removeItem(Material itemName, int amount = 1)
    {
        if (!_items.ContainsKey(itemName) || _items[itemName] < amount) {
            return false;
        }
        _items[itemName] -= amount;
        if (_items[itemName] <= 0)
            _items[itemName] = 0;
        return true;
    }
    public int GetItemCount(Material itemName)
    {
        return _items[itemName];
    }
    public void Clear()
    {
        _items.Clear();
    }
}

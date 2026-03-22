using Godot;
using Godot.Collections;
using System;

public partial class ItemManager : Node
{
    public static ItemManager Instance { get; private set; }

    private Dictionary<Materials, int> _items = new();

    public override void _Ready()
    {
        if (Instance != null && Instance != this)
        {
            QueueFree();
            return;
        }

        Instance = this;
    }

    public void AddItem(Materials itemName, int amount = 1)
    {
        if (_items.ContainsKey(itemName))
            _items[itemName] += amount;
        else
            _items[itemName] = amount;
    }

    public bool RemoveItem(Materials itemName, int amount = 1)
    {
        if (!_items.ContainsKey(itemName) || _items[itemName] < amount)
            return false;

        _items[itemName] -= amount;

        if (_items[itemName] <= 0)
            _items.Remove(itemName);

        return true;
    }

    public int GetItemCount(Materials itemName)
    {
        return _items.ContainsKey(itemName) ? _items[itemName] : 0;
    }

    public Dictionary<Materials, int> GetAll()
    {
        return new Dictionary<Materials, int>(_items);
    }

    public void Clear()
    {
        _items.Clear();
    }
}

using Godot;
using System;
using Godot.Collections;

public partial class CookingUi : Control
{
    [Export]
    PackedScene ItemDisplayScene { get; set; }
    [Export]
    HBoxContainer Box { get; set; }
    private int index;
    private int size = 5;
    private Godot.Collections.Array items = [];
    public override void _Ready()
    {
        var items = ItemManager.Instance.GetAll();
        foreach (var entry in items)
        {
            Materials material = entry.Key;
            int amount = entry.Value;
            ItemDisplay itemDisplay = ItemDisplayScene.Instantiate<ItemDisplay>();
            itemDisplay.Input = $"{material}: {amount}";
            string path = $"res://Assets/Collectables/{material}.png";
            itemDisplay.Image = GD.Load<Texture2D>(path);
            Box.AddChild(itemDisplay);
        }
    }

}

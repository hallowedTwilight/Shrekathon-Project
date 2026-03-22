using Godot;
using System;

public partial class ItemDisplay : MarginContainer
{
    [Export] public Texture2D Image { get; set; }
    [Export] public TextureRect TextureRect { get; set; }
    [Export] public Label Text { get; set; }
    [Export] public string Input { get; set; }

    public override void _Ready()
    {
        if (TextureRect != null && Image != null)
            TextureRect.Texture = Image;

        if (Text != null)
            Text.Text = Input ?? "";
    }
}
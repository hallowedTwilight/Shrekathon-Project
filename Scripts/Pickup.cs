using Godot;
using System;

public partial class Pickup : Area2D
{
	[Export]
	public Materials material;
	[Export]
	public int quantity;
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}
	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D && body.Name == "Player")
		{
			ItemManager.Instance.AddItem(material, quantity);
			GD.Print(ItemManager.Instance.GetItemCount(material));
			QueueFree();
		}
	}

}

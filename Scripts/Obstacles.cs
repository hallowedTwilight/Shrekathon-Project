using Godot;
using System;

public partial class Obstacles : Area2D
{
	[Export]
	public int Damage {get; set;} = 1;
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}
	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D && body.Name == "Player")
		{
			Player p = body as Player;
			HealthComponent health = p.HealthComponent;
			health.SetHealth(health.Health - Damage);
			QueueFree();
		}
	}
}

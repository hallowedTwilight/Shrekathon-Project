using Godot;
using System;
public partial class HealthComponent : Node
{
	[Export]
	public float Health {get; set;} = 10;
	[Export]
	public float DrainRate {get; set;} = 1;

	public override void _Process(double delta)
	{
		if (Health > 0)
		{
			Health -= DrainRate * (float)delta;
			GD.Print(Health);
		}
		else{
			GetTree().ChangeSceneToFile("res://Scenes/cooking.tscn");
		}
	}
}

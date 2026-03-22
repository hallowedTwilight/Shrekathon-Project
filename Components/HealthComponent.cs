using Godot;
using System;
public partial class HealthComponent : Node
{
	[Export]
	public float Health = 10;
	[Export]
	public float DrainRate = 1;

	public override void _Process(double delta)
	{
		if (Health > 0)
		{
			Health -= DrainRate * (float)delta;
		}
		else{
			GetTree().ChangeSceneToFile("res://Scenes/cooking.tscn");
		}
	}

}

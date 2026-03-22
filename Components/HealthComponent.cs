using Godot;
using System;
public partial class HealthComponent : Node
{
	// public Node cookingphase;
	[Export]
	public float Health = 10;
	[Export]
	public float DrainRate = 1;
	// public HealthComponent()
	// {
	//     cookingphase = ResourceLoader.Load<PackedScene>("res://Scenes/cooking.tscn").Instantiate();
	// }
	// public void _AddASceneManually()
	// {
	//     GetTree().Root.AddChild(cookingphase);
	// }

	public override void _Process(double delta)
	{
		if (Health > 0)
		{
			Health -= DrainRate * (float)delta;
		}
		else{
			// _AddASceneManually();
			GD.Print("Moving Scene");
			GetTree().ChangeSceneToFile("res://Scenes/cooking.tscn");
		}
	}

}

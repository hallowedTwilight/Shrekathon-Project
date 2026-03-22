using Godot;
using System;

public Node cookingphase;

public letsgetcooking()
{
	cookingphase = ResourceLoader.Load<PackedScene>("res://Scenes/cooking.tscn").Instantiate();
}

public void _AddASceneManually()
{
	// This is like autoloading the scene, only
	// it happens after already loading the main scene.
	GetTree().Root.AddChild(cookingphase);
}

public partial class HealthComponent : Node
{
	[Export]
	public float Health = 10;
	[Export]
	public float DrainRate = 1;
	public override void _Process(double delta)
	{
		if(Health > 0)
		{
			Health -= DrainRate * (float) delta;
		} else:
			//no clue if this actually works lmao
			_AddASceneManually()
			SceneTree.change_scene_to_packed(cookingphase)
		{
		}
	}

}

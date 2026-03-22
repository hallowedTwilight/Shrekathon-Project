using Godot;
using System;

public partial class Cooking : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("game_jump")){
			GetTree().ChangeSceneToFile("res://Scenes/running_scene.tscn");
		}
	}
}

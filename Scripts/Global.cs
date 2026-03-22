using Godot;
using System;

public partial class Global : Node
{
	public static Global Instance { get; private set; }
	[Export]
	public int Speed {get; set;} = 10;
	[Export]
	public float Health{get; set;} = 15f;
	[Export]
	public float Velocity{get; set;} = -400f;
	public int JumpCounter = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

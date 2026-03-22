using Godot;
using System;

public partial class ObjectGroup : Node2D
{
	[Export]
	public float Speed {get; set;} = -5.0f;
	[Export]
	public Vector2 Range {get; set;} = new Vector2(0.0f,0.0f);
	public override void _Process(double delta)
	{
		Vector2 position = Position;
		position.X += Speed * (float)delta;
		Position = position;
		if(Position.X < -350)
		{
			QueueFree();
		}
	}
}

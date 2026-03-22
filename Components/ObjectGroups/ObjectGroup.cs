using Godot;
using System;

public partial class ObjectGroup : Node2D
{
<<<<<<< HEAD
    [Export]
    public float Speed {get; set;} = -250.0f;
    [Export]
    public Vector2 Range {get; set;} = new Vector2(0.0f,0.0f);
    [Export]
    public float Delay {get; set;} = 5.0f;
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
=======
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
>>>>>>> refs/remotes/origin/main

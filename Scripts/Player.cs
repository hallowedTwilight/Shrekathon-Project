using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public JumpComponent JumpComponent {get; set;}
	[Export]
	public HealthComponent HealthComponent {get; set;}
	[Export]
	public int Speed = 3;
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("game_jump"))
		{
			JumpComponent.RequestJump();
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
        float horizontalVelocity = velocity.X;
        Velocity = velocity;
        MoveAndSlide();
        Velocity = new Vector2(horizontalVelocity, Velocity.Y);
	}
}

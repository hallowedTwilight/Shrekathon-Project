using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public Sprite2D Sprite { get; set; }
    public float Health { get; set; }
    public int Speed { get; set; }
    [Export]
    public float JumpSpeed { get; set; }
    [Export]
    public float Gravity { get; set; }
    public bool CanJump { get; set; }
    public override void _Ready()
    {
        CanJump = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        velocity.Y += Gravity * (float)delta;
        Velocity = velocity;
        MoveAndSlide();
    }
    public override void _Input(InputEvent @event)
    {
        var velocity = Velocity;
        if (Input.IsActionPressed("game_jump"))
        {
            GD.Print("jump");
            velocity.Y = JumpSpeed;
        }
        Velocity = velocity;
    }
    public void OnArea2DBodyEntered(Node2D body)
    {
        GD.Print("Entered");
        if (body is StaticBody2D)
        {
            CanJump = true;
        }
    }
    public void OnArea2DBodyExited(Node2D body)
    {
        GD.Print("Exited");
        if (body is StaticBody2D)
        {
            CanJump = false;
        }
    }
}

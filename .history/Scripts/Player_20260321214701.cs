using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    JumpComponent JumpComponent {get; set;}
    [Export]
    HealthComponent HealthComponent {get; set;}
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
        MoveAndSlide();
    }
}

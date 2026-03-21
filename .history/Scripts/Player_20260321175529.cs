using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // Velocities
    [Export] 
    public float JumpVelocity = -400f;
    [Export] 
    public float Gravity = 1000f;
    [Export] 
    public float FallGravityMultiplier = 1.8f;
    [Export] 
    public float LowJumpMultiplier = 2.5f;
    [Export] 
    public float CoyoteTime = 0.12f;
    [Export] 

    // Timers 
    public float JumpBufferTime = 0.1f;
    private float coyoteTimer;
    private float jumpBufferTimer;

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("game_jump"))
        {
            jumpBufferTimer = JumpBufferTime;
        }
    }
    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;
        var velocity = Velocity;

        jumpBufferTimer -= dt;

        // Coyote time for more forgiving jumps
        if (IsOnFloor()) {
            coyoteTimer = CoyoteTime;
        } else {
            coyoteTimer -= dt;
        }

        // Gravity code for decelerating. 
        if (velocity.Y > 0) {
            velocity.Y += Gravity * FallGravityMultiplier * dt;
        } else {
            velocity.Y += Gravity * dt;
        }

        // Variable jump height
        if (!Input.IsActionPressed("game_jump") && velocity.Y < 0)
        {
            velocity.Y += Gravity * (LowJumpMultiplier - 1) * dt;
        }

        // 
        if (jumpBufferTimer > 0 && coyoteTimer > 0)
        {
            velocity.Y = JumpVelocity;
            jumpBufferTimer = 0;
            coyoteTimer = 0;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}

using Godot;
using System;

public partial class HoverJumpComponent : Node
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
    public float JumpBufferTime = 0.1f;
    [Export]
    public float HoverTime = 1f;
    // Timers
    private float _coyoteTimer;
    private float _jumpBufferTimer;
    private float _hoverTimer;
    private CharacterBody2D _body;
    public override void _Ready()
    {
        _body = GetParent<CharacterBody2D>();

        if (_body == null)
        {
            GD.PushError("JumpComponent must be a child of CharacterBody2D");
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_body == null) return;

        float dt = (float)delta;
        var velocity = _body.Velocity;

        // --- Timers ---
        _jumpBufferTimer -= dt;

        if (_body.IsOnFloor())
        {
            _coyoteTimer = CoyoteTime;
        }
        else
        {
            _coyoteTimer -= dt;
        }

        // --- Gravity ---
        if (velocity.Y > 0)
        {
            velocity.Y += Gravity * FallGravityMultiplier * dt;
        }
        else
        {
            velocity.Y += Gravity * dt;
        }

        // --- Variable jump height ---
        if (!Input.IsActionPressed("game_jump") && velocity.Y < 0)
        {
            velocity.Y += Gravity * (LowJumpMultiplier - 1) * dt;
        }

        // --- Jump ---
        if (_jumpBufferTimer > 0 && _coyoteTimer > 0)
        {
            velocity.Y = JumpVelocity;
            _jumpBufferTimer = 0;
            _coyoteTimer = 0;
        }

        _body.Velocity = velocity;
    }
    public void RequestJump()
    {
        _jumpBufferTimer = JumpBufferTime;
    }
}
using Godot;
using System;

public partial class JumpComponent : Node
{
    // Velocities
    [Export] public float JumpVelocity = -400f;
    [Export] public float Gravity = 1000f;
    [Export] public float FallGravityMultiplier = 1.8f;
    [Export] public float LowJumpMultiplier = 2.5f;

    // Jump Assistance
    [Export] public float CoyoteTime = 0.12f;
    [Export] public float JumpBufferTime = 0.1f;

    // Timers
    protected float _coyoteTimer;
    protected float _jumpBufferTimer;

    protected CharacterBody2D _body;

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
        UpdateTimers(dt);
        HandleJump(ref velocity);
        ApplyGravity(ref velocity, dt);
        ApplyVariableJump(ref velocity, dt);
        _body.Velocity = velocity;
    }

    protected virtual void UpdateTimers(float dt)
    {
        _jumpBufferTimer -= dt;

        if (_body.IsOnFloor()){
            _coyoteTimer = CoyoteTime;
        }else{
            _coyoteTimer -= dt;
        }
    }

    protected virtual void HandleJump(ref Vector2 velocity)
    {
        if (_jumpBufferTimer > 0 && _coyoteTimer > 0){
            velocity.Y = JumpVelocity;
            _jumpBufferTimer = 0;
            _coyoteTimer = 0;
        }
    }

    protected virtual void ApplyGravity(ref Vector2 velocity, float dt)
    {
        if (velocity.Y > 0){
            velocity.Y += Gravity * FallGravityMultiplier * dt;
        }else{
            velocity.Y += Gravity * dt;
        }
    }

    protected virtual void ApplyVariableJump(ref Vector2 velocity, float dt)
    {
        if (!Input.IsActionPressed("game_jump") && velocity.Y < 0){
            velocity.Y += Gravity * (LowJumpMultiplier - 1) * dt;
        }
    }

    public virtual void RequestJump()
    {
        _jumpBufferTimer = JumpBufferTime;
    }
}
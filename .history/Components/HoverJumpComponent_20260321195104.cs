using Godot;
using System;

public partial class HoverJumpComponent : JumpComponent
{
    [Export] public float HoverTime = 1f;
    [Export] public float HoverGravityMultiplier = 0.2f;

    private float _hoverTimer;
    private bool _isHovering;

    protected override void UpdateTimers(float dt)
    {
        base.UpdateTimers(dt);

        if (_body.IsOnFloor())
        {
            _hoverTimer = HoverTime;
            _isHovering = false;
        }
    }

    protected override void HandleJump(ref Vector2 velocity)
    {
        bool jumped = false;

        if (_jumpBufferTimer > 0 && _coyoteTimer > 0)
        {
            velocity.Y = JumpVelocity;
            _jumpBufferTimer = 0;
            _coyoteTimer = 0;

            _hoverTimer = HoverTime;
            jumped = true;
        }

        if (jumped)
        {
            _isHovering = false;
        }
    }

    protected override void ApplyGravity(ref Vector2 velocity, float dt)
    {
        bool holdingJump = Input.IsActionPressed("game_jump");

        // --- Hover logic ---
        if (holdingJump && _hoverTimer > 0 && velocity.Y < 0)
        {
            _isHovering = true;
            _hoverTimer -= dt;
        }
        else
        {
            _isHovering = false;
        }

        float gravityToApply = Gravity;

        if (_isHovering)
        {
            gravityToApply *= HoverGravityMultiplier;
        }
        else if (velocity.Y > 0)
        {
            gravityToApply *= FallGravityMultiplier;
        }

        velocity.Y += gravityToApply * dt;
    }

    protected override void ApplyVariableJump(ref Vector2 velocity, float dt)
    {
        if (!_isHovering && !Input.IsActionPressed("game_jump") && velocity.Y < 0)
        {
            velocity.Y += Gravity * (LowJumpMultiplier - 1) * dt;
        }
    }
}
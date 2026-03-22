using Godot;
using System;

public partial class HoverJumpComponent : JumpComponent
{
    public float ApexThreshold = 20f;
    [Export] 
    public float HoverTime = 1f;
    private float _hoverTimer;
    private bool _isHovering;
    private bool _hoverUsed;
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
        if (_jumpBufferTimer > 0 && _coyoteTimer > 0)
        {
            velocity.Y = JumpVelocity;
            _jumpBufferTimer = 0;
            _coyoteTimer = 0;
            _hoverTimer = HoverTime;
            _isHovering = false;
        }
    }
    protected override void ApplyGravity(ref Vector2 velocity, float dt)
    {
        bool holdingJump = Input.IsActionPressed("game_jump");
        bool atApex = Mathf.Abs(velocity.Y) < ApexThreshold;
        if (!_hoverUsed && holdingJump && atApex && _hoverTimer > 0)
        {
            _isHovering = true;
            _hoverUsed = true;
        }
        if (_isHovering && holdingJump && _hoverTimer > 0)
        {
            _hoverTimer -= dt;
            velocity.Y = 0f;
            return;
        }else{
            _isHovering = false;
        }
        float gravityToApply = Gravity;
        if (velocity.Y > 0){
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
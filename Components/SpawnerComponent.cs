using Godot;
using System;
using System.Collections.Generic;

public partial class SpawnerComponent : Node2D
{
    [Export] public float Delay { get; set; } = 5.0f;
    private float _delayTimer;
    private RandomNumberGenerator _rng = new RandomNumberGenerator();
    [Export] public PackedScene[] Scenes;
    public override void _Ready()
    {
        _rng.Randomize();
        _delayTimer = 0f;
        if (Scenes == null || Scenes.Length == 0)
        {
            GD.PushWarning("SpawnerComponent: No scenes assigned!");
        }
    }
    public override void _Process(double delta)
    {
        _delayTimer += (float)delta;
        if (_delayTimer >= Delay)
        {
            _delayTimer = 0f;

            if (Scenes != null && Scenes.Length > 0)
            {
                int index = _rng.RandiRange(0, Scenes.Length - 1);
                Spawn(Scenes[index]);
            }
        }
    }

    public void Spawn(PackedScene scene)
    {
        var instance = scene.Instantiate<Node2D>();
        if (instance is ObjectGroup group)
        {
            float yOffset = _rng.RandfRange(group.Range.X, group.Range.Y);
            group.Position = new Vector2(Position.X, Position.Y + yOffset);
            GetParent().AddChild(group);
            Delay = group.Delay;
        }
        else
        {
            GD.PushError("Scene is not an ObjectGroup!");
            instance.QueueFree();
        }
    }
}
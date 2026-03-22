using Godot;
using System;
using System.Collections.Generic;

public partial class SpawnerComponent : Node2D
{
    [Export] public float Delay { get; set; } = 5.0f;
    private float _delayTimer;
    private RandomNumberGenerator _rng = new RandomNumberGenerator();
    private string _path = "res://Components/ObjectGroups";
    private List<PackedScene> _scenes = new List<PackedScene>();
    public override void _Ready()
    {
        _rng.Randomize();
        var dir = DirAccess.Open(_path);
        if (dir == null)
        {
            GD.PushError("Failed to open directory: " + _path);
            return;
        }
        dir.ListDirBegin();
        while (true)
        {
            string fileName = dir.GetNext();
            if (fileName == "")
                break;
            if (dir.CurrentIsDir())
                continue;
            if (fileName.EndsWith(".tscn"))
            {
                string fullPath = _path + "/" + fileName;
                var scene = ResourceLoader.Load<PackedScene>(fullPath);
                if (scene != null)
                {
                    _scenes.Add(scene);
                    GD.Print("Loaded: " + fullPath);
                }
                else
                {
                    GD.PushError("Failed to load: " + fullPath);
                }
            }
        }
        dir.ListDirEnd();
        _delayTimer = 0f;
    }
    public override void _Process(double delta)
    {
        _delayTimer += (float)delta;
        if (_delayTimer >= Delay)
        {
            _delayTimer = 0f;
            if (_scenes.Count > 0)
            {
                int index = _rng.RandiRange(0, _scenes.Count - 1);
                Spawn(_scenes[index]);
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
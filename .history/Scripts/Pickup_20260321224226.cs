using Godot;
using System;

public partial class Pickup : Area2D
{
    [Export]
    public Materials material;
    [Export]
    public int quantity;
    
}
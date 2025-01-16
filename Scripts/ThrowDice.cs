using Godot;
using System;

public partial class ThrowDice : Node
{
	[Export] public Node3D body;
	[Export] public Node3D dice;
	[Export] public float throwForce;
	private RigidBody3D rigidBody;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rigidBody = dice.GetNode<RigidBody3D>("DicePhysics");
		GD.Print(rigidBody.Name);
	}

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("Shoot"))
        {
			rigidBody.ApplyForce((dice.GlobalPosition - body.GlobalPosition).Normalized() * throwForce);
        }
    }
}

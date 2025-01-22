using Godot;
using System;

public partial class DebugName : RayCast3D
{
	[Export] private RayCast3D rayCast;
	[Export] private ThrowDice throwDice;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//throwDice = (ThrowDice)td.GetScript();
		GD.Print(throwDice.Name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (rayCast.IsColliding() && Input.IsActionJustPressed("Shoot"))
		{
			Vector3 collisionPoint = rayCast.GetCollisionPoint();
			Node3D collisionObject = (Node3D)rayCast.GetCollider();
			string collisionName = collisionObject.Name;
			throwDice.Dice = collisionObject;
			GD.Print($"Hit {collisionName} at {collisionPoint}");
		}
	}
}

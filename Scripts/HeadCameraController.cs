using Godot;
using System;

public partial class HeadCameraController : Node3D
{
    [Export] private Camera3D camera;
    [Export] private Node3D head;
    [Export] public float mouseSensitivity = 1.0f;
    [Export] public float maxVerticalAngle = 90f;
    private float verticalRotation = 0.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //This is just to popup the cursor and close the window
        if (Input.IsActionJustPressed("Escape"))
        {
			Input.MouseMode = Input.MouseModeEnum.Visible;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        //Check if an event is mousemotion, then rotate horizontally only the head and clamp the rotation Y angle of the camera.
        if (@event is InputEventMouseMotion mouseMovement)
        {
            head.RotateY(-mouseMovement.Relative.X * mouseSensitivity);
            //head.RotateX(mouseMovement.Relative.Y * mouseSensitivity);
            verticalRotation += -mouseMovement.Relative.Y * mouseSensitivity;
        }

        Mathf.Clamp(verticalRotation, Mathf.DegToRad(-maxVerticalAngle), Mathf.DegToRad(maxVerticalAngle));
        head.Rotation = new Vector3(verticalRotation, head.Rotation.Y, 0);
    }

}

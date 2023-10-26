using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static Controls _controls;

    public static void Init(Player myPlayer)
    {
        _controls = new Controls();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        _controls.Game.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
            
        };

        _controls.Game.Jump.started += _ =>
        {
            myPlayer.SetJump(); 
        };

        _controls.Game.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _controls.Game.Shoot.started += ctx =>
        {
            myPlayer.Shoot();
        };

        _controls.Game.Reload.performed += ctx =>
        {
            myPlayer.Reload();
        };

        _controls.Permanent.Enable();


    }

    public static void Gamemode()
    {
        _controls.Game.Enable();
        _controls.UI.Disable();
    }

    public static void UImode()
    {
        _controls.UI.Enable();
        _controls.Game.Disable();
    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ClickToMove_Player _playerScript;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo) && hitInfo.collider.name.ToLower() == "floor")
            {
                Vector3 moveToPosition = hitInfo.point;
                _playerScript.MovePlayerToPosition(moveToPosition);
            }
        }
    }
}

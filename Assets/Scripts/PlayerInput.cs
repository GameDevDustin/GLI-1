using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    
    private void Update() 
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit rayHit;
            Ray rayOrigin = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayOrigin, out rayHit))
            {
                Transform goHit = rayHit.transform;
            }
        }
    }
}

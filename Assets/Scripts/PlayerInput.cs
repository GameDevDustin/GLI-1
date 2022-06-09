using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    
    private void Update() 
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit rayHit;
            Ray rayOrigin = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(rayOrigin, out rayHit))
            {
                Transform goHit = rayHit.transform;
                Debug.Log("goHit name: " + goHit.gameObject.GetComponent<MeshFilter>().mesh.name.ToLower());
                if (goHit.transform.GetComponent<MeshFilter>().mesh.name.ToLower().StartsWith("cube"))
                {
                    ChangeGOColor(goHit.gameObject);
                }
            }
        }
    }

    private void ChangeGOColor(GameObject goToBeChanged)
    {
        goToBeChanged.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
    }
}

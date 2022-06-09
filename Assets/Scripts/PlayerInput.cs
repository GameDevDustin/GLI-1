using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Color = UnityEngine.Color;
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
                string meshName = goHit.transform.GetComponent<MeshFilter>().mesh.name.ToLower();
                Material goMaterial;

                switch (meshName)
                {
                    case string expression when meshName.StartsWith("cube"):
                        ChangeGOColor(goHit.gameObject, true);
                        break;
                    case string expression when meshName.StartsWith("cylinder"):
                        goMaterial = goHit.gameObject.GetComponent<MeshRenderer>().material;
                        if (goMaterial != null && goMaterial.color != Color.black)
                        { goMaterial.color = Color.black; ChangeGOColor(goHit.gameObject, false, goMaterial); }
                        break;
                }
            }
        }
    }

    private void ChangeGOColor(GameObject goToBeChanged, bool isRandom)
    {
        if (isRandom)
        { goToBeChanged.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV(); }
    }

    private void ChangeGOColor(GameObject goToBeChanged, bool isRandom, Material material)
    { goToBeChanged.GetComponent<MeshRenderer>().material.color = material.color; }
}

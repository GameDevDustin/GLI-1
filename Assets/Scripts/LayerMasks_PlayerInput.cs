using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LayerMasks_PlayerInput : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, 1000f, 1 << 6))
            {
                hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}

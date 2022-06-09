using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstantSpheres_PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _goSpherePrefab;


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit rayHit;
            Ray rayOrigin = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(rayOrigin, out rayHit))
            {
                //Debug.Log("Impact point: " + rayHit.point);
                Vector3 newPosition = rayHit.point + new Vector3(0, 0.45f, 0);
                Instantiate(_goSpherePrefab, newPosition, Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootWeapon : MonoBehaviour
{ 
    [SerializeField] private GameObject _bulletHolePrefabGO;
    [SerializeField] private Camera _mainCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_bulletHolePrefabGO, hitInfo.point + new Vector3(0f, 0.01f, -0.01f), Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}

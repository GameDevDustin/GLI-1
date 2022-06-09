using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectRays_Sphere : MonoBehaviour
{
    private float raycastDistance = 1f;
    private Rigidbody _rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.blue);

        RaycastHit hitInfo;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, raycastDistance))
        {
            if (hitInfo.collider.name == "Floor")
            {
                _rigid.isKinematic = true;
                _rigid.useGravity = false;
            }
            
            
            
            
            // transform.GetComponent<Rigidbody>().useGravity = false;
            // transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawLine(transform.position, transform.position + new Vector3(0f, -raycastDistance, 0f));
    // }
}

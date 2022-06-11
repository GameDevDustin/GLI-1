using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickToMove_Player : MonoBehaviour
{
    private Vector3 _moveToPosition;
    private bool _movePlayerActive;
    private float _moveSpeed = 3f;
    private float _playerHeight = 1f;

    // Update is called once per frame
    void Update()
    {
        if (_movePlayerActive)
        {
            float distance = Vector3.Distance(transform.position, _moveToPosition);
            
            if (distance > 0.05f)
            { MovePlayer(); }
            else
            { _movePlayerActive = false; }
        }
    }

    private void MovePlayer()
    {
        float step = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _moveToPosition, step);
    }
    
    public void MovePlayerToPosition(Vector3 targetPosition)
    {
        _moveToPosition = targetPosition + new Vector3(0f, _playerHeight / 2f, 0f);
        _movePlayerActive = true;
    }
}

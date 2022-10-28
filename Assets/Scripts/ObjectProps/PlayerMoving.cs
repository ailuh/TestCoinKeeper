using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private float _speed = 20f;
    private Rigidbody _rigidBody;
    private Vector3 _movementVector;


    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    void FixedUpdate()
    {
        if (_movementVector != Vector3.zero)
        {
            moveCharacter(_movementVector);
        }
    }


    void moveCharacter(Vector3 direction)
    {
        _rigidBody.velocity = direction * _speed;
    }

}

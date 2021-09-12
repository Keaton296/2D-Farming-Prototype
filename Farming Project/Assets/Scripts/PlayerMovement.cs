using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    public void Move()
    {
        Vector3 movementdirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if(movementdirection.magnitude > 1) movementdirection.Normalize();
        movementdirection *= movespeed*Time.deltaTime;
        transform.position += movementdirection; 
    }
}

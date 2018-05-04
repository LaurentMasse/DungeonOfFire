using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We collided with : "+ collision.collider.tag);
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flooter : MonoBehaviour
{   
    [Header("Outside variables")]
    [Tooltip("The rigidbody attached to the player")]
    public Rigidbody2D rb;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -1, 1));
        }
    }
}

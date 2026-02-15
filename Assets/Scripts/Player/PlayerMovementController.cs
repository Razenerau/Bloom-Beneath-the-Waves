using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerModel playerModel;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(rb.velocity.magnitude > 1f)
        {
            rb.velocity = new Vector2(horizontal * playerModel.Speed * PlayerModel.OneOverSqrt2, vertical * playerModel.Speed * PlayerModel.OneOverSqrt2);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * playerModel.Speed, vertical * playerModel.Speed);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public float movementSpeed;
    public float jumpForce;
    public bool isGrounded;

    public LayerMask groundLayer;
    public Rigidbody2D myBody;

    private float energySpend = 1;
    private Collider2D characterCollider;
    #endregion

    void Start()
    {
        characterCollider = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //finding the ground
        isGrounded = Physics2D.IsTouchingLayers(characterCollider, groundLayer);

        myBody.velocity = new Vector2(movementSpeed, myBody.velocity.y);

        Jump();
        GroundCheck();
    }

    private void GroundCheck()
    {
        if (isGrounded == true)
        {
            StartCoroutine(EnergyBar.instance.regenEnergy());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (EnergyBar.instance.currentEnergy > 0)
            {
                EnergyBar.instance.UseFart(energySpend);
                myBody.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}

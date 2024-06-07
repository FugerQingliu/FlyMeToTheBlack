using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float invincibleTime;
    public float jumpSpeed;
    public float forwardSpeed;
    public bool isInvincible;
    public bool isDead;
    private Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        playerInputActions.Player.Fire.started += Jump;
    }
    private void Start()
    {
        rb.velocity = new Vector3(forwardSpeed, 0, 0);
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    private void Jump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0);
        //Debug.Log("Jump");
    }

    public void Die()
    {
        if (!isInvincible)
        {
            Debug.Log("Die");
            isDead = true;
        }
    }
    private IEnumerator InvincibleCounter()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible=false;
    }
}

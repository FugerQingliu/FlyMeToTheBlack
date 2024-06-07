using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float jumpSpeed;
    public float forwardSpeed;
    public bool isInvincible;
    public float invincibleTime;
    private Rigidbody2D rb;
    public PlayerInputActions playerInputActions;
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
        Debug.Log("Jump");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collections")
        {
            isInvincible = true;
            Destroy(collision.gameObject);
            StartCoroutine(InvincibleCounter());
        }
    }
    public void Die()
    {
        if(!isInvincible)
            Debug.Log("Die");
    }
    private IEnumerator InvincibleCounter()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible=false;
    }
}

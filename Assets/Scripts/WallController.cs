using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public PlayerInputController playerInputController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInputController = collision.GetComponent<PlayerInputController>();
            if(!(playerInputController.isDead))
                playerInputController.Die();
        }
    }
}

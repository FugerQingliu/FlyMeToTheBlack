using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectionsController : MonoBehaviour
{
    protected TemperationController tc;
    protected PlayerInputController pic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tc = collision.GetComponent<TemperationController>();
        pic = collision.GetComponent<PlayerInputController>();
        SpecialEffects();
    }
    abstract public void SpecialEffects();
}

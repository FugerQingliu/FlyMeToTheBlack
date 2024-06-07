using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : CollectionsController
{
    GameObject blackScreen;
    SpriteRenderer bs;
    private void Awake()
    {
        blackScreen = GameObject.Find("BlackScreen");
        bs = blackScreen.GetComponent<SpriteRenderer>();
        //Debug.Log("Shadow awake");
    }
    public override void SpecialEffects()
    {
        //if (blackScreen == null)
            //Debug.Log("NOT FOUND");
        if (!(pic.isInvincible))
        {
            pic.isInvincible = true;
            bs.enabled = true;
            StartCoroutine(Reset());
        }
    }
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(pic.invincibleTime);
        pic.isInvincible = false;
        bs.enabled= false;
    }
}
